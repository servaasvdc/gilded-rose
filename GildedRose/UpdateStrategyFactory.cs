using System.Collections.Generic;

namespace GildedRoseKata;

public class UpdateStrategyFactory
{
    private readonly Dictionary<string, IUpdateStrategy> _nonRegularItemStrategies = new();
    private readonly IUpdateStrategy _regularItemStrategy = new RegularItemStrategy();

    public UpdateStrategyFactory()
    {
        _nonRegularItemStrategies[Constants.Sulfuras] = new SulfurasStrategy();
        _nonRegularItemStrategies[Constants.AgedBrie] = new AgedBrieStrategy();
        _nonRegularItemStrategies[Constants.BackstagePass] = new BackstagePassStrategy();
        _nonRegularItemStrategies[Constants.ConjuredItem] = new ConjuredItemStrategy();
    }

    public IUpdateStrategy GetStrategy(string name)
    {
        if (name.StartsWith("Conjured"))
        {
            return _nonRegularItemStrategies["Conjured Item"];
        }

        if (name.StartsWith("Backstage pass"))
        {
            return _nonRegularItemStrategies["Backstage pass"];
        }
        
        return _nonRegularItemStrategies.GetValueOrDefault(name, _regularItemStrategy);
    }
}