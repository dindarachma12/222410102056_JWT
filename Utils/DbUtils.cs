using Npgsql;

namespace percobaan1.Utils
{
    public class DbUtils
    {
        private NpgsqlConnection connection;
        private string credentials;

        public DbUtils(string credentials)
        {
            this.credentials = credentials;
            this.connection = new NpgsqlConnection();
            this.connection.ConnectionString = credentials;
        }

        public NpgsqlCommand GetNpgsqlCommand(string query)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            return command;
        }

        public void closeConnection()
        {
            this.connection.Close();
        }
    }
}
