using ShoppingBird.Fly.DbModels;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class NewInvoiceModel
    {
        public Invoice Invoice { get; set; }
        public List<CartItemModel> CartItems { get; set; }
    }
}
