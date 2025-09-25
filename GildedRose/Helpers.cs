using System;

namespace GildedRoseKata;

internal static class Helpers
{
    private const int MinQuality = 0;
    private const int MaxQuality = 50;
    
    public static int DecreaseQuality(int quality, int by)
    {
        // Rule: "The Quality of an item is never negative"
        return Math.Max(MinQuality, quality - by);
    }

    public static int IncreaseQuality(int quality, int by)
    {
        // Rule: "The Quality of an item is never more than 50"
        return Math.Min(MaxQuality, quality + by);
    }
}