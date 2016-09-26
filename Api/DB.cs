using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Api
{
    public class DB
    {
        private static readonly string connectionString = @"Data Source=CEYHUN-PC;Initial Catalog=integration;Integrated Security=True";
        public SqlConnection connection = new SqlConnection(connectionString);
        private SqlCommand command;

        public SqlCommand Command(string query)
        {
            command = new SqlCommand(query, connection);
            return command;
        }


    }
}