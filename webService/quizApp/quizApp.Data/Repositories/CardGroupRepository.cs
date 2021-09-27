using quizApp.Data.Entities;
using quizApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.Data.Repositories
{
    public class CardGroupRepository : ISqlRepository<CardGroup>
    {
        public delegate ISqlRepository<Card> DepencyInject();

        private readonly SqlConnection _sqlConnection;
        private readonly SqlTransaction _transaction;
        private readonly SqlCommand _command;
        private readonly DepencyInject _depencyInject;
        public CardGroupRepository(SqlConnection sqlConnection, SqlTransaction transaction, DepencyInject depencyInject)
        {
            this._depencyInject = depencyInject;
            this._sqlConnection = sqlConnection;
            this._transaction = transaction;
            _command = new SqlCommand();
        }

        public IEnumerable<CardGroup> GetAll()
        {
            string sqlExpression = string.Format("SELECT * FROM CardGroupSet");
            return ExecSelect(sqlExpression).ToList();
        }

        public CardGroup Get(int id)
        {
            string sqlExpression = string.Format("SELECT * FROM CardGroupSet WHERE Id = '{0}'", id);
            var group = ExecSelect(sqlExpression).FirstOrDefault();
            group.CardSet = IncludeCard(group.Id);

            return group;
        }

        public IEnumerable<CardGroup> Find(Func<CardGroup, bool> predicate)
        {
            string sqlExpression = string.Format("SELECT * FROM CardGroupSet");
            return ExecSelect(sqlExpression).Where(predicate).ToList();
        }

        public void Create(CardGroup cardGroup)
        {
            var exist = Find(g => g.Title == cardGroup.Title).FirstOrDefault();
            if (exist == null)
            {
                var sqlParams = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@title",
                        Value = cardGroup.Title
                    },
                };
                cardGroup.Id = InsertExe("sp_InsertGroup", sqlParams);
            }
            else
            {
                cardGroup.Id = exist.Id;
            }

            foreach (var card in cardGroup.CardSet)
            {
                card.GroupSet.Add(cardGroup);
                _depencyInject().Create(card);
            }
        }

        public void Update(CardGroup cardGroup)
        {
            string sqlExpression = string.Format("UPDATE CardGroupSet SET Title = '{0}' Where Id = '{1}'", cardGroup.Title, cardGroup.Id);
            ExecUpdate(sqlExpression);
        }

        public void Delete(int id)
        {
            string sqlExpression = string.Format("DELETE FROM CardGroupSet WHERE Id = '{0}'", id);
            ExecUpdate(sqlExpression);
        }

        private int InsertExe(string sqlExpression, IEnumerable<SqlParameter> sqlParams)
        {
            _command.CommandText = sqlExpression;
            _command.Connection = _sqlConnection;
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Transaction = _transaction;
            _command.Parameters.Clear();
            foreach (var item in sqlParams)
            {
                _command.Parameters.Add(item);
            }
            int id;
            var result = _command.ExecuteScalar();
            int.TryParse(result.ToString(), out  id);
            return id;
        }

        private void ExecUpdate(string sqlExpression)
        {
            _command.CommandText = sqlExpression;
            _command.Connection = _sqlConnection;
            _command.CommandType = System.Data.CommandType.Text;
            _command.Transaction = _transaction;
            try
            {
                _command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private ICollection<Card> IncludeCard(int groupId)
        {
            string sqlExpression = string.Format("SELECT CardSet.Id, CardSet.TranslatedWord, CardSet.DirectWord FROM CardGroupCard JOIN CardSet ON CardSet.Id = CardGroupCard.CardId JOIN GroupSet ON GroupCard.GroupId = GroupSet.Id WHERE GroupSet.Id = '{0}'", groupId);

            return _depencyInject().ExecSelect(sqlExpression).ToList();
        }

        public IEnumerable<CardGroup> ExecSelect(string sqlExpression)
        {
            _command.CommandText = sqlExpression;
            _command.Connection = _sqlConnection;
            _command.CommandType = System.Data.CommandType.Text;
            _command.Transaction = _transaction;

            using (SqlDataReader reader = _command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new CardGroup
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                        };
                    }
                }
            }
        }
    }
}
