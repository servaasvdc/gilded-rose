using System;

namespace GildedRoseKata;

internal static class Helpers
{
    public static int DecreaseQuality(int quality, int by)
    {
        return Math.Max(Constants.MinQuality, quality - by);
    }

    public static int IncreaseQuality(int quality, int by)
    {
        return Math.Min(Constants.MaxQuality, quality + by);
    }
}