public class Chatbot : ICustomerSupportHandler
{
    private ICustomerSupportHandler Handler;
    public Chatbot(ICustomerSupportHandler handler)
    {
        this.Handler = handler;
    }
    public void HandleIssue(Issue issue)
    {
        if (issue.GetPriority().Equals("LEVEL1"))
        {
            issue.SetStatus("RESOLVED");
            Console.WriteLine("Chatbot handles the issue: " + issue.GetName() + " with priority: " + issue.GetPriority() + " and status: " + issue.GetStatus());
        }
        else
        {
            issue.SetStatus("PENDING");
            Console.WriteLine("Chatbot cannot handle the issue: " + issue.GetName() + " status: " + issue.GetStatus() + "\nMoving to customer support executive");
            Handler.HandleIssue(issue);
        }
    }
}