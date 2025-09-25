﻿using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private readonly UpdateStrategyFactory _updateStrategyFactory = new();
    
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                var strategy = _updateStrategyFactory.GetStrategy(item.Name);
                strategy.UpdateItem(item);
                continue;
            }
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                    
                    if (item.Name == "Conjured Mana Cake")
                    {
                        item.Quality = item.Quality - 1;
                    }   
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {

                            item.Quality = item.Quality - 1;
                            
                            if (item.Name == "Conjured Mana Cake")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}