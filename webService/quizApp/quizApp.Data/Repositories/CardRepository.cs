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
    public class CardRepository : ISqlRepository<Card>
    {
        private readonly SqlConnection sqlConnection;
        private readonly SqlTransaction transaction;
        private readonly SqlCommand command;
        public CardRepository(SqlConnection sqlConnection, SqlTransaction transaction)
        {
            this.sqlConnection = sqlConnection;
            this.transaction = transaction;
            command = new SqlCommand();
        }

        public void Create(Card card)
        {
            var exist = Find(c => c.TranslatedWord == card.TranslatedWord && c.DirectWord == card.DirectWord).FirstOrDefault();
            if (exist == null)
            {
                var sqlParams = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        ParameterName = "@TranslatedWord",
                        Value = card.TranslatedWord
                    },
                    new SqlParameter
                    {
                        ParameterName = "@DirectWord",
                        Value = card.DirectWord
                    }
                };
                card.Id = InsertExe("sp_InsertCard", sqlParams);
            }
            else
            {
                card.Id = exist.Id;
            }
            foreach (var group in card.GroupSet)
            {
                Create(card.Id, group.Id);
            }
        }

        private void Create(int CardId, int GroupId)
        {
            var sqlParams = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@CardId",
                    Value = CardId
                },
                new SqlParameter
                {
                    ParameterName = "@CardGroupId",
                    Value = GroupId
                }
            };

            InsertExe("sp_InsertRelation", sqlParams);
        }

        public void Delete(int id)
        {
            string sqlExpression = string.Format("DELETE FROM CardSet WHERE Id = '{0}'", id);
            ExecUpdate(sqlExpression);
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            string sqlExpression = string.Format("SELECT * FROM CardSet");
            return ExecSelect(sqlExpression).Where(predicate).ToList();
        }

        public Card Get(int id)
        {
            string sqlExpression = string.Format("SELECT * FROM CardSet WHERE Id = '{0}'", id);
            return ExecSelect(sqlExpression).FirstOrDefault();
        }

        public IEnumerable<Card> GetAll()
        {
            string sqlExpression = string.Format("SELECT * FROM CardSet");
            return ExecSelect(sqlExpression).ToList();
        }

        public void Update(Card card)
        {
            string sqlExpression = string.Format("UPDATE CardSet SET TranslatedWord = '{0}', DirectWord = '{1}' Where Id = '{2}'", card.TranslatedWord, card.DirectWord, card.Id);
            ExecUpdate(sqlExpression);
        }

        private int InsertExe(string sqlExpression, IEnumerable<SqlParameter> sqlParams)
        {
            command.CommandText = sqlExpression;
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Transaction = transaction;
            command.Parameters.Clear();
            foreach (var item in sqlParams)
            {
                command.Parameters.Add(item);
            }
            try
            {
                int id;
                var result = command.ExecuteScalar();
                int.TryParse(result.ToString(), out id);
                return id;
            }
            catch
            {
                return default(int);
            }

        }

        private void ExecUpdate(string sqlExpression)
        {
            command.CommandText = sqlExpression;
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.Text;
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public IEnumerable<Card> ExecSelect(string sqlExpression)
        {
            command.CommandText = sqlExpression;
            command.Connection = sqlConnection;
            command.CommandType = System.Data.CommandType.Text;
            command.Transaction = transaction;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return new Card
                        {
                            Id = reader.GetInt32(0),
                            TranslatedWord = reader.GetString(1),
                            DirectWord = reader.GetString(2)
                        };
                    }
                }
            }
        }
    }
}
