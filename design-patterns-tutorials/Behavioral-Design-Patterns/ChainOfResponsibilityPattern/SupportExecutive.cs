public class SupportExecutive : ICustomerSupportHandler
{
    private ICustomerSupportHandler Handler;
    public SupportExecutive(ICustomerSupportHandler handler)
    {
        this.Handler = handler;
    }
    public void HandleIssue(Issue issue)
    {
        if (issue.GetPriority().Equals("LEVEL2"))
        {
            issue.SetStatus("RESOLVED");
            Console.WriteLine("Support Executive handles the issue: " + issue.GetName() + " with priority: " + issue.GetPriority() + " and status: " + issue.GetStatus());
        }
        else
        {
            issue.SetStatus("PENDING");
            Console.WriteLine("Support Executive cannot handle the issue: " + issue.GetName() + " status: " + issue.GetStatus() + "\nMoving to tech team");
            Handler.HandleIssue(issue);
        }
    }
}