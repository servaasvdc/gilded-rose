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

        var decreaseBy = 1;
        if (item.SellIn >= 0)
        {
            decreaseBy = 1;
        }
        else
        {
            // Rule: "Once the sell by date has passed, Quality degrades twice as fast"
            decreaseBy = 2;
        }

        // Rule: "At the end of each day our system lowers the value for Quality for every item"
        item.Quality = item.Quality - decreaseBy;
    }
}

public class SulfurasStrategy : IUpdateStrategy
{
    public void UpdateItem(Item item)
    {
        // Rule: "Sulfuras", being a legendary item, never has to be sold or decreases in Quality.
    }
}