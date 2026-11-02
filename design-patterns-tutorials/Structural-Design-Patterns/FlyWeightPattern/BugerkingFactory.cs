public class BurgerkingFactory
{
    private Dictionary<string, BurgerkingBurger> _burgerCache = new Dictionary<string, BurgerkingBurger>();
    public BurgerkingBurger CreateBurger(string burgerName, string bavrages, string subordinateItems)
    {
        if (_burgerCache.TryGetValue(burgerName, out BurgerkingBurger burger))
        {
            return burger;
        }
        else
        {
            burger = new BurgerkingBurger();
            burger.CreateBurger(burgerName, bavrages, subordinateItems);
            _burgerCache[burgerName] = burger;
            return burger;
        }
    }
}