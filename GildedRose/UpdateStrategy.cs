using System;

namespace GildedRoseKata;

public interface IUpdateStrategy
{
    void UpdateItem(Item item);
}

public class RegularItemStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn -= 1;

        int decreaseQualityBy;
        if (item.SellIn >= 0)
        {
            decreaseQualityBy = 1;
        }
        else
        {
            // Rule: "Once the sell by date has passed, Quality degrades twice as fast"
            decreaseQualityBy = 2;
        }

        // Rule: "At the end of each day our system lowers the value for Quality for every item"
        // Rule: "The Quality of an item is never negative"
        item.Quality = Math.Max(0, item.Quality - decreaseQualityBy);
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
        int increaseQualityBy;
        if (item.SellIn >= 0)
        {
            increaseQualityBy = 1;
        }
        else
        {
            // Rule: "Once the sell by date has passed, Quality increases twice as fast"
            increaseQualityBy = 2;
        }

        // Rule: "At the end of each day our system increases the value for Quality for every item"
        // Rule: "The Quality of an item is never more than 50"
        item.Quality = Math.Min(50, item.Quality + increaseQualityBy);
    }
}

public class BackstagePassStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn--;

        switch (item.SellIn)
        {
            // Rules:
            // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            //
            // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            // Quality drops to 0 after the concert
            case < 0:
                item.Quality = 0;
                break;
            case < 5:
                item.Quality = Math.Min(50, item.Quality + 3);
                break;
            case < 10:
                item.Quality = Math.Min(50, item.Quality + 2);
                break;
            default:
                item.Quality = Math.Min(50, item.Quality + 1);
                break;
        }
    }
}

public class ConjuredItemStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "At the end of each day our system lowers the value for SellIn for every item"
        item.SellIn--;
        

        // Rule: ""Conjured" items degrade in Quality twice as fast as normal items"
        int decreaseQualityBy;
        if (item.SellIn >= 0)
        {
            decreaseQualityBy = 2;
        }
        else
        {
            // Rule: "Once the sell by date has passed, Quality degrades twice as fast"
            decreaseQualityBy = 4;
        }

        // Rule: "At the end of each day our system lowers the value for Quality for every item"
        // Rule: "The Quality of an item is never negative"
        item.Quality = Math.Max(0, item.Quality - decreaseQualityBy);
    }
}
