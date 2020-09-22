using ShoppingBird.Fly.Models;
using ShoppingBird.Mobile.ViewModels;
using System.Collections.Generic;

namespace ShoppingBird.Mobile.Models
{
    public class CartItem : BindableBase
    {
        private int _quantity;
        private double _retailPrice;
        private double _taxAmount;
        private double _amount;
        private string _description;

        public CartItem()
        {
            this.TaxData = new List<TaxModel>();
            this.Store = new StoreModel();
            SetDemoTax();
            this.Quantity = 1;
        }

        private void SetDemoTax()
        {
            var tax = new TaxModel() { Percent = 6 };
            TaxData.Add(tax);
        }

        public CartItem GetPartialInvoiceItem(Product product, double retailPrice, double taxRate)
        {
            //todo: Get all tax models which applies to this specific item
            TaxData.Clear();
            var tax = new TaxModel() { Percent = taxRate };
            TaxData.Add(tax);

            this.ItemId = product.Id;
            this.Barcode = product.Item.Split('|')[0].Trim();
            this.Description = product.Item.Split('|')[1].Trim();
            this.RetailPrice = retailPrice;
            //this.TaxAmount = CaluateTax();
            //this.Amount = RetailPrice + TaxAmount;
            UpdatePriceData();
            return this;
        }
        public int ItemId { get; set; }
        public string Description
        {
            get => _description; set
            {
                if (_description == value) return;
                _description = value;
                NotifyPropertyChanged();
            }
        }
        public string Barcode { get; set; }
        public int Quantity
        {
            get => _quantity; set
            {
                if (_quantity == value) return;
                _quantity = value;
                NotifyPropertyChanged();
                UpdatePriceData();
            }
        }

        public double RetailPrice
        {
            get => _retailPrice; set
            {
                if (_retailPrice == value) return;
                _retailPrice = value;
                UpdatePriceData();
                NotifyPropertyChanged();
            }
        }
        public List<TaxModel> TaxData { get; set; }
        public string Unit { get; set; }
        public double TaxAmount
        {
            get => _taxAmount; set
            {
                if (_taxAmount == value) return;
                _taxAmount = value;
                NotifyPropertyChanged();
            }
        }
        public double Amount
        {
            get => _amount; set
            {
                if (_amount == value) return;
                _amount = value;
                NotifyPropertyChanged();
            }
        }

        public void UpdatePriceData()
        {
            TaxAmount = CaluateTax();
            this.Amount = ((Quantity * RetailPrice) + TaxAmount);
        }

        private double CaluateTax()
        {
            var tax = 0d;
            foreach (var item in TaxData)
            {
                tax += ((item.Percent / 100) * (RetailPrice * Quantity));
            }
            return tax;
        }

        //used only with saving and loading cart data from local storage
        public StoreModel Store { get; set; }

    }
}
