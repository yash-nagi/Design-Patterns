public class TechTeam : ICustomerSupportHandler
{
    public TechTeam()
    {
    }
    public void HandleIssue(Issue issue)
    {
        if (issue.GetPriority().Equals("LEVEL3"))
        {
            issue.SetStatus("RESOLVED");
            Console.WriteLine("Tech team handles the issue: " + issue.GetName() + " with priority: " + issue.GetPriority() + " and status: " + issue.GetStatus());
        }
        else
        {
            issue.SetStatus("FAILED");
            Console.WriteLine("Tech team cannot handle the issue: " + issue.GetName() + " status: " + issue.GetStatus() + "\nIssue cannot be resolved");
        }
    }
}