using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class NewInvoiceModel
    {
        public InvoiceModel Invoice { get; set; }
        public List<CartItemModel> CartItems { get; set; }
    }
}
