public class ProxyDatabase : IDatabase
{
    private RealDataBase _realDatabase;
    private Dictionary<int, string> _cache;
    private bool _isConnected;

    public ProxyDatabase()
    {
        _realDatabase = new RealDataBase();
        _cache = new Dictionary<int, string>();
    }

    public string GetDataForId(int id)
    {
        if (_isConnected == false)
        {
            return "Not connected to the database.";
        }
        else
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }
            else
            {
                string data = _realDatabase.GetDataForId(id);
                _cache[id] = data;
                return data;
            }
        }
    }
    public void LogIn()
    {
        _isConnected = true;
    }
    public void LogOut()
    {
        _isConnected = false;
    }
    public bool IsConnected()
    {
        return _isConnected;
    }
}