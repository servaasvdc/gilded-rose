using GildedRoseKata;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task Snapshot()
    {
        Item[] items = [
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 },
            new() { Name = "Aged Brie", SellIn = -1, Quality = 40 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 },
            new() { Name = "Cursed Stone Idol", SellIn = -10, Quality = 5 },
            new() { Name = "Devout Zealot's Ring", SellIn = 2, Quality = 0 },
            new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
            new() { Name = "Aged Brie", SellIn = 5, Quality = 40 },
            new() { Name = "Aged Brie", SellIn = 10, Quality = 50 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 }
        ];
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        return Verifier.Verify(items);
    }
    
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}