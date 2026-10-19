public class CreateDatabaseConnection
{
    public List<DatabaseConnection> CreateConnection()
    {
        DatabaseConnection connection = new DatabaseConnection()
        {
            // Set the properties of the connection object
            Server = "localhost",
            Port = "5432",
            Database = "mydb",
            username = "myuser",
            password = "mypass",
            SslMode = true
        };

        var connection2 = connection.Clone();
        connection2.Server = "remotehost";
        connection2.Port = "5433";
        connection2.Database = "mydb2";
        connection2.username = "myuser2";
        connection2.password = "mypass2";
        connection2.SslMode = false;

        return new List<DatabaseConnection> { connection, connection2 };
    }
}