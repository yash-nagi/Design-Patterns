public class ProxyBurger
{
    public string SauceType { get; set; }
    public string Suppliment { get; set; }
    public string PattyType { get; set; }
    public BurgerkingBurger Burger { get; set; }
    public ProxyBurger(string sauceType, string suppliment, string pattyType, BurgerkingBurger burger)
    {
        SauceType = sauceType;
        Suppliment = suppliment;
        PattyType = pattyType;
        Burger = burger;
    }
    public void AddOns(string sauceType, string suppliment, string pattyType)
    {
        Burger.AddOns(sauceType, suppliment, pattyType);
    }
}