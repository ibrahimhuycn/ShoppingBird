using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class PriceListModel
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int StoreId { get; set; }
        public string StoreDescription { get; set; }
        public decimal RetailPrice { get; set; }
        public int UnitId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
