using System;

namespace Bazar
{
    public static class StaticData
    {
        //Customer
        public static readonly string[] customerNames = { "Ali Baba", "Charles Dickens", "Arnold", "Spiderman", "Danger Joe" };

        //Shop
        public static readonly string[] shopNames = { "Deluxe Kebab", "Rælingen Pizza", "Svingen", "Rema 1000", "GSport" };

        // Items
        public static readonly string[] itemNames = { "Chicken", "Lam", "Steak", "Pork" };
        public static readonly float[] itemPrices = { 30f, 23f, 100f, 45f };
    }
}
