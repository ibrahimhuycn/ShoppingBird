using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
