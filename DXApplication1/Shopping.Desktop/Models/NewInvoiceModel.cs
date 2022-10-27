using ShoppingBird.Desktop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Desktop.Models
{
    public class NewInvoiceModel
    {
        public InvoiceModel Invoice { get; set; }
        public List<CartItemModel> CartItems { get; set; }
    }
}
