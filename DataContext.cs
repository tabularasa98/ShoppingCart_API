using DynamicButtons.Models;
using System.Collections.Generic;
using System;


namespace shoppingCart
{
    public static class DataContext
    {
        public static List<InventoryItem> Inventory = new List<InventoryItem> {
            new ProductByQuantity { Name = "Apples", Description = "Red", Price = 0.75 },
            new ProductByQuantity { Name = "Apples", Description = "Green", Price = 0.80 },
            new ProductByQuantity { Name = "Avacados", Description = "Hass", Price = 0.90 },
            new ProductByQuantity { Name = "Cereal", Description = "Froot Loops", Price = 2.30 },
            new ProductByQuantity { Name = "Cereal", Description = "Frosted Flakes", Price = 2.30 },
            new ProductByQuantity { Name = "Cereal", Description = "Oatmeal", Price = 1.50 },
            new ProductByQuantity { Name = "Watermelon", Description = "Seedless", Price = 5.00 },
            new ProductByQuantity { Name = "Chips", Description = "Doritos", Price = 2.99 },
            new ProductByQuantity { Name = "Chips", Description = "Lays", Price = 2.89 },
            new ProductByQuantity { Name = "Popcorn", Description = "White Cheddar", Price = 3.00 },
            new ProductByWeight { Name = "Bananas", Description = "Ripe", Price = .49 },
            new ProductByWeight { Name = "Plantains", Description = "Ripe", Price = .59 },
            new ProductByWeight { Name = "Ham", Description = "Black Forest", Price = .79 },
            new ProductByWeight { Name = "Ham", Description = "Maple", Price = .79 },
            new ProductByWeight { Name = "Chicken", Description = "Baked", Price = 1.50 },
            new ProductByWeight { Name = "Chicken", Description = "Fried", Price = 1.50 },
            new ProductByWeight { Name = "Turkey", Description = "Baked", Price = 1.70 },
            new ProductByWeight { Name = "Turkey", Description = "Smoked", Price = 1.70 },
            new ProductByWeight { Name = "Fish", Description = "Tuna", Price = 2.30 },
            new ProductByWeight { Name = "Fish", Description = "Salmon", Price = 2.15 },
        };
        public static List<Product> Cart = new List<Product> { };
        public static List<InventoryItem> Results = new List<InventoryItem> { };
    }
}
