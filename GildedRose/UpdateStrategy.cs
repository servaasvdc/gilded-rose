using System;

namespace GildedRoseKata;

public interface IUpdateStrategy
{
    void UpdateItem(Item item);
}

internal static class Constants
{
    public const int MinQuality = 0;
    public const int MaxQuality = 50;
}

public class RegularItemStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn -= 1;

        // Rule: "Once the sell by date has passed, Quality degrades twice as fast"
        var decreaseQualityBy = item.SellIn >= 0 ? 1 : 2;

        // Rule: "At the end of each day our system lowers the value for Quality for every item"
        // Rule: "The Quality of an item is never negative"
        item.Quality = Math.Max(Constants.MinQuality, item.Quality - decreaseQualityBy);
    }
}

public class SulfurasStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "Sulfuras", being a legendary item, never has to be sold or decreases in Quality.
    }
}

public class AgedBrieStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn -= 1;
        
        // Rule: ""Aged Brie" actually increases in Quality the older it gets"
        // Rule: "Once the sell by date has passed, Quality increases twice as fast"
        var increaseQualityBy = item.SellIn >= 0 ? 1 : 2;

        // Rule: "At the end of each day our system increases the value for Quality for every item"
        // Rule: "The Quality of an item is never more than 50"
        item.Quality = Math.Min(Constants.MaxQuality, item.Quality + increaseQualityBy);
    }
}

public class BackstagePassStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn--;

        item.Quality = item.SellIn switch
        {
            // Rules:
            // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            //
            // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            // Quality drops to 0 after the concert
            < 0 => 0,
            < 5 => Math.Min(Constants.MaxQuality, item.Quality + 3),
            < 10 => Math.Min(Constants.MaxQuality, item.Quality + 2),
            _ => Math.Min(Constants.MaxQuality, item.Quality + 1)
        };
    }
}

public class ConjuredItemStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn--;
        
        // Rule: ""Conjured" items degrade in Quality twice as fast as normal items"
        // Rule: "Once the sell by date has passed, Quality degrades twice as fast"
        var decreaseQualityBy = item.SellIn >= 0 ? 2 : 4;

        // Rule: "At the end of each day our system lowers the value for Quality for every item"
        // Rule: "The Quality of an item is never negative"
        item.Quality = Math.Max(Constants.MinQuality, item.Quality - decreaseQualityBy);
    }
}


