using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class UpdateQualityShould
{
    private readonly List<Item> _items;
    private readonly GildedRose _sut;

    public UpdateQualityShould()
    {
        _items = [];
        _sut = new GildedRose(_items);
    }
    
    [Fact]
    public void NotChangeName()
    {
        // Arrange
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = 10, Quality = 5 });
        
        // Act
        _sut.UpdateQuality();
        
        // Assert
        Assert.Equal("Cursed Stone Idol", _items[0].Name);
    }
    
    [Fact]
    public void MakeSellByDateApproachBy1()
    {        
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = 10, Quality = 5 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(9, _items[0].SellIn);
    }
    
    [Fact]
    public void DegradeQualityBy1()
    {        
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = 10, Quality = 5 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(4, _items[0].Quality);
    }

    [Fact]
    public void DegradeQualityBy2_WhenSellByDatePassed()
    {        
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = -10, Quality = 5 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(3, _items[0].Quality);
    }

    [Fact]
    public void NotLowerQualityBelow0()
    {
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = 5, Quality = 0 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(0, _items[0].Quality);
    }
    
    [Fact]
    public void IncreaseQualityOfAgedBrie()
    {
        _items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(1, _items[0].Quality);
    }
    
    [Fact]
    public void NotIncreaseQualityAbove50()
    {
        _items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(50, _items[0].Quality);
    }
    
    [Fact]
    public void NotChangeSellByDate_WhenItemIsSulfuras()
    {
        _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(5, _items[0].SellIn);
    }
    
    [Fact]
    public void NotChangeQuality_WhenItemIsSulfuras()
    {
        _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(40, _items[0].Quality);
    }
    
    [Fact]
    public void IncreaseInQualityBy1_WhenItemIsBackstagePass_AndSellDateIsMoreThan10DaysAway()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(41, _items[0].Quality);
    }
    
    [Fact]
    public void IncreaseInQualityBy2_WhenItemIsBackstagePass_AndSellDateIs10DaysOrLessAway()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(42, _items[0].Quality);
    }
    
    [Fact]
    public void IncreaseInQualityBy3_WhenItemIsBackstagePass_AndSellDateIs5DaysOrLessAway()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(43, _items[0].Quality);
    }
    
    [Fact]
    public void SetQualityTo0_WhenItemIsBackstagePass_AndSellDateHasPassed()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(0, _items[0].Quality);
    }
}