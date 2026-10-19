public class DatabaseConnection : ICloneable<DatabaseConnection>
{
    private string connectionString;
    public string Server;
    public string Port;
    public string Database;
    public string username;
    public string password;
    public bool SslMode;

    public DatabaseConnection()
    {
        // Default constructor
    }
    // Private copy constructor for deep cloning
    private DatabaseConnection(DatabaseConnection other)
    {
        this.Server = other.Server;
        this.Port = other.Port;
        this.Database = other.Database;
        this.username = other.username;
        this.password = other.password;
        this.SslMode = other.SslMode;
    }

    public DatabaseConnection Clone()
    {
        return new DatabaseConnection(this);
    }

    public string GetConnectionString()
    {
        return $"Server={Server};Port={Port};Database={Database};Username={username};Password={password};SslMode={SslMode}";
    }
}