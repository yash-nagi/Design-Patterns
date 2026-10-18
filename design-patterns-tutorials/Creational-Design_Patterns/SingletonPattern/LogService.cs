public class LogService
{
    private static LogService _instance;
    private static readonly object _lock = new object();

    private LogService() { }

    public static LogService Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LogService();
                    }
                }
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        // Implementation for logging the message
        Console.WriteLine($"Log: {message}");
    }
}