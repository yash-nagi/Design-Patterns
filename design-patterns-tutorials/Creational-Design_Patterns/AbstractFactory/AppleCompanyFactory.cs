public class AppleCompanyFactory : IPhoneEcosystem
{
    public IPhone CreatePhone()
    {
        IPhone phone = new ApplePhone();
        return phone;
    }

    public IEarbuds CreateBuds()
    {
        IEarbuds buds = new AppleEarbuds();
        return buds;
    }

    public IWatch CreateWatch()
    {
        IWatch watch = new AppleWatch();
        return watch;
    }
}