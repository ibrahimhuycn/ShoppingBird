using System;

namespace ShoppingBird.Fly.DbModels
{
    public class Tax
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
