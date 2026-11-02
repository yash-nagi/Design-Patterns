public class RealDataBase : IDatabase
{
    public string GetDataForId(int id)
    {
        // Simulating a database call
        return $"Data for ID: {id}";
    }
}