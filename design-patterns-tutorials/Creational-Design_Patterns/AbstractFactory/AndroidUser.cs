public class AndroidUser
{
    public void BuyAndroidProducts()
    {
        IPhoneEcosystem iphoneEcosystem = new SamsungCompanyFactory();
        IPhone phone = iphoneEcosystem.CreatePhone();
        phone.MakeCall();

        IEarbuds buds = iphoneEcosystem.CreateBuds();
        buds.PlayMusic();

        IWatch watch = iphoneEcosystem.CreateWatch();
        watch.Track();
    }
}