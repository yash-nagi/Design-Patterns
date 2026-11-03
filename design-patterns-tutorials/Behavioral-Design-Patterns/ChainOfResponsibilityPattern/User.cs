public class User
{
    private ICustomerSupportHandler Handler;
    public User(ICustomerSupportHandler handler)
    {
        this.Handler = handler;
    }
    public void RaiseIssue(Issue issue)
    {
        Handler.HandleIssue(issue);
    }
}