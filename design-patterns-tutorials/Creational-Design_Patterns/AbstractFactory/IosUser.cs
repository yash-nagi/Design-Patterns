public class IosUser
{
    public void BuyIosProducts()
    {
        IPhoneEcosystem iphoneEcosystem = new AppleCompanyFactory();
        IPhone phone = iphoneEcosystem.CreatePhone();
        phone.MakeCall();

        IEarbuds buds = iphoneEcosystem.CreateBuds();
        buds.PlayMusic();

        IWatch watch = iphoneEcosystem.CreateWatch();
        watch.Track();
    }
}