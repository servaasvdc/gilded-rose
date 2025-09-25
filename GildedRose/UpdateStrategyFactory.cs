using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class UpdateStrategyFactory
{
    private readonly Dictionary<string, IUpdateStrategy> _nonRegularItemStrategies = new();
    private readonly IUpdateStrategy _regularItemStrategy = new RegularItemStrategy();

    public UpdateStrategyFactory()
    {
        _nonRegularItemStrategies["Sulfuras, Hand of Ragnaros"] = new SulfurasStrategy();
        _nonRegularItemStrategies["Aged Brie"] = new AgedBrieStrategy();
        _nonRegularItemStrategies["Backstage passes to a TAFKAL80ETC concert"] = new BackstagePassStrategy();
        _nonRegularItemStrategies["Conjured Mana Cake"] = new ConjuredItemStrategy();
    }

    public IUpdateStrategy GetStrategy(string name)
    {
        if (_nonRegularItemStrategies.TryGetValue(name, out var strategy))
        {
            return strategy;
        }

        return _regularItemStrategy;
    }
}