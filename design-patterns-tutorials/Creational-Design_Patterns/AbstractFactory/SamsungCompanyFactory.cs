public class SamsungCompanyFactory : IPhoneEcosystem
{
    public IPhone CreatePhone()
    {
        IPhone phone = new SamsungPhone();
        return phone;
    }

    public IEarbuds CreateBuds()
    {
        IEarbuds buds = new SamsungEarbuds();
        return buds;
    }

    public IWatch CreateWatch()
    {
        IWatch watch = new SamsungWatch();
        return watch;
    }
}