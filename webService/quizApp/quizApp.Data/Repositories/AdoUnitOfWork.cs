using quizApp.Data.Entities;
using quizApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.Data.Repositories
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private SqlConnection sqlConnection;
        private SqlTransaction transaction;
        private CardGroupRepository.DepencyInject _depencyInject;
        public AdoUnitOfWork(string connectionString)
        {
            connectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {

            }
            transaction = sqlConnection.BeginTransaction();
            _depencyInject = () => SqlCardSet;
        }
        private CardRepository cardRepository;
        private CardGroupRepository _cardGroupRepository;
        private ISqlRepository<Card> SqlCardSet
        {
            get
            {
                if (cardRepository == null)
                {
                    cardRepository = new CardRepository(sqlConnection, transaction);
                }
                return cardRepository;
            }
        }
        public ISqlRepository<CardGroup> SqlCardGroupSet
        {
            get
            {
                if (_cardGroupRepository == null)
                {
                    _cardGroupRepository = new CardGroupRepository(sqlConnection, transaction, _depencyInject);
                }
                return _cardGroupRepository;
            }
        }

        public IRepository<Card> CardSet => SqlCardSet;

        public IRepository<CardGroup> GroupSet => SqlCardGroupSet;


        public void Save()
        {
            transaction.Commit();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    sqlConnection.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
