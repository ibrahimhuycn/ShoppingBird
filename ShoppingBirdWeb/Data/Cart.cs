using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBirdWeb.Data
{
    public class Cart : Product
    {
        private float qty;

        public float Qty
        {
            get => qty;
            set
            {
                qty = value;
                Amount = qty * RetailPrice;
            }
        }
        public float Amount { get; private set; }

    }
}
