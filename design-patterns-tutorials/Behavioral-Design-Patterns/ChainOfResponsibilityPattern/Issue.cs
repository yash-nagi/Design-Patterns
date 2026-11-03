public class Issue
{
    private string Priority;
    private string Status;
    private string Name;
    public Issue(string name, string priority, string status)
    {
        this.Name = name;
        this.Priority = priority;
        this.Status = status;
    }
    public string GetPriority()
    {
        return this.Priority;
    }
    public string GetStatus()
    {
        return this.Status;
    }
    public string GetName()
    {
        return this.Name;
    }
    public void SetStatus(string status)
    {
        this.Status = status;
    }
}