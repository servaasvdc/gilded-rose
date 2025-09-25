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
        _items.Add(new Item { Name = "Cursed Stone Idol", SellIn = 10, Quality = 5 });
        
        _sut.UpdateQuality();
        
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
    
    [Theory]
    [InlineData(11, 40, 41)]
    [InlineData(10, 40, 42)]
    [InlineData(5, 40, 43)]
    public void IncreaseInQuality_WhenItemIsBackstagePass(int sellIn, int quality, int expectedQuality)
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(41, _items[0].Quality);
    }
    
    [Fact]
    public void SetQualityTo0_WhenItemIsBackstagePass_AndSellDateHasPassed()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 40 });
        
        _sut.UpdateQuality();
        
        Assert.Equal(0, _items[0].Quality);
    }
    
    [Theory]
    [InlineData(5, 10, 8)]
    [InlineData(1, 10, 8)]
    [InlineData(-1, 10, 6)]
    public void DegradeConjuredItemsTwiceAsFast(int sellIn, int quality, int expectedQuality)
    {
        _items.Add(new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        
        _sut.UpdateQuality();
        
        Assert.Equal(expectedQuality, _items[0].Quality);  
    }
}