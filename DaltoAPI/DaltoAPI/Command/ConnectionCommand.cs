using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using Npgsql;
using System.Data;

namespace DaltoAPI.Command
{

    public class ConnectionCommand:IDisposable
    {
        private readonly NpgsqlConnection conn;

        private static string connectionString = "Server=127.0.0.1;Port=5432;Database=daltodb;User Id=dalto;Password=root;";

        public ConnectionCommand()
        {
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public NpgsqlConnection GetConnection()
        {
            return conn;
        }
    }
}