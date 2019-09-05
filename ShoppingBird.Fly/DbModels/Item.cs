using System;

namespace ShoppingBird.Fly.DbModels
{
    public class Item
    {
        public int MyProperty { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
