using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Mobile.Models
{
    public class TaxModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Percent { get; set; }
    }
}
