using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class UpdateStrategyFactory
{
    private readonly Dictionary<string, IUpdateStrategy> _strategies = new();
    private readonly IUpdateStrategy _strategy = new RegularItemStrategy();

    public UpdateStrategyFactory()
    {
        _strategies["Sulfuras, Hand of Ragnaros"] = new SulfurasStrategy();
    }

    public IUpdateStrategy GetStrategy(string name)
    {
        if (_strategies.TryGetValue(name, out var strategy))
        {
            return strategy;
        }

        throw new ArgumentException($"Cannot find a strategy associated with {name}");
    }
}