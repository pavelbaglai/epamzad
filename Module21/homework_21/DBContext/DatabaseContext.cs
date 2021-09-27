using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace homework_21.DBContext
{
    public class DatabaseContext
    {
        private readonly string _connectionString;
        private string _queryString;
        private SqlConnection _connection;

        public DatabaseContext()
        {
            SetPath();
            _connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\DB\Univercsity.mdf;Integrated Security = True";
        }
        public void SetPath()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        public void QueryBuilder(string QueryStr)
        {
            _queryString = QueryStr;
        }

        public int ExecNonQuery(params SqlParameter[] parameters)
        {
            _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                using (SqlCommand command = new SqlCommand(_queryString, _connection))
                { 
                        _connection.Open();
                        if (parameters!=null)
                            command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }
        public SqlDataReader ExecReader()
        {
            _connection = new SqlConnection(_connectionString);
            using (SqlCommand command = new SqlCommand(_queryString, _connection))
            {
                _connection.Open();

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
        }


    }
}