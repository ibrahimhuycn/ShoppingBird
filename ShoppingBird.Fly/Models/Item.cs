using System;

namespace ShoppingBird.Fly.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public ItemCategory SubCategory { get; set; }
    }
}
