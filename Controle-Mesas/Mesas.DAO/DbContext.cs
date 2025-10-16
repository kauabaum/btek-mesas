using MySql.Data.MySqlClient;
using System;

namespace Mesas
{
    public class DbContext : IDisposable
    {
        private string connectionString = "server=127.0.0.1;port=3306;database=pesqueiro_senia;user=root";
        private MySqlConnection _connection;

        public MySqlConnection GetConnection()
        {
            if (_connection == null || _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection = new MySqlConnection(connectionString);
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}
