using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class PriceListModel : NotifyBase
    {
        private decimal _retailPrice;
        private string _barcode;

        public int Id { get; set; }
        public string Barcode
        {
            get => _barcode; set
            {
                _barcode = value;
                OnPropertyChanged();
            }
        }
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int StoreId { get; set; }
        public string StoreDescription { get; set; }
        public decimal RetailPrice
        {
            get => _retailPrice; set
            {
                _retailPrice = value;
                OnPropertyChanged();
            }
        }
        public int UnitId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
