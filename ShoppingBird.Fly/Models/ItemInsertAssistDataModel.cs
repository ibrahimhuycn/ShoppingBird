using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ItemInsertAssistDataModel
    {
        public int UnitId { get; set; }
        public int TaxId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ErrorMessage { get; set; } = null;
    }
}
