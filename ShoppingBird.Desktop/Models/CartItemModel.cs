using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class CartItemModel : NotifyBase
    {
        private decimal _quantity;
        private decimal _amount;

        public CartItemModel()
        {
            Quantity = 1;
        }
        public string Barcode { get; set; }
        public int ItemId { get; set; }
        public int StoreId { get; set; }
        public decimal RetailPrice { get; set; }
        public string ItemDescription { get; set; }
        public string Unit { get; set; }
        public decimal Quantity
        {
            get => _quantity; set
            {
                _quantity = value;
                OnPropertyChanged();
                Amount = RetailPrice * value;
            }
        }

        #region UI Only property
        public decimal Amount
        {
            get => _amount; set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}