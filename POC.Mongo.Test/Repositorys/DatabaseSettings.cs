namespace POC.Mongo.Test.Repositorys
{
    public class DatabaseSettings
    {
        public DatabaseSettings(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
