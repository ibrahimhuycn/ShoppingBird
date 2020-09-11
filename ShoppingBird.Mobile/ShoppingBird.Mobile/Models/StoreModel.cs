using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Mobile.Models
{
    public class StoreModel : Fly.Models.Store
    {
        public override string ToString()
        {
            return this.Name;
        }
    }
}