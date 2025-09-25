using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly UpdateStrategyFactory _updateStrategyFactory = new();
    
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            var strategy = _updateStrategyFactory.GetStrategy(item.Name);
            strategy.UpdateItem(item);
        }
    }
}