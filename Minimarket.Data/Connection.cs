using System.Data.SqlClient;

namespace Minimarket.Data
{
    public class Connection
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;
        private readonly string _dbName;
        private readonly bool _security;

        private static Connection Con = null;

        private Connection()
        {
            this._host = "CLOPEZDEV";
            this._dbName = "BD_MINIMARKET";
            this._user = "clopez";
            this._password = "holamundo";
            this._security = false;
        }

        public SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new();
            try
            {
                sqlConnection.ConnectionString = $"Server={this._host}; Database={this._dbName};";
                if (_security)
                {
                    sqlConnection.ConnectionString += "Integrated Security = SSPI";
                }
                else
                {
                    sqlConnection.ConnectionString += $"User Id={this._user}; Password={this._password}";
                }
            }
            catch (Exception ex)
            {
                sqlConnection = null;
                throw ex;
            }
            return sqlConnection;
        }

        public static Connection GetConnection()
        {
            Con ??= new Connection();
            return Con;
        }
    }
}
