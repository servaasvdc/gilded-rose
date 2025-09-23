namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    
    /// <summary>
    /// Denotes the number of days we have to sell the item. At the end of each day, this value is decremented by 1.
    /// </summary>
    public int SellIn { get; set; }
    
    /// <summary>
    /// Denotes how valuable the item is.
    /// </summary>
    /// <remarks>
    /// Cannot be negative. There is also a maximum, depending on the exact item.
    /// </remarks>
    public int Quality { get; set; }
}
