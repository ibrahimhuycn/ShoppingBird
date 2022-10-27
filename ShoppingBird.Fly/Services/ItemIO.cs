using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Services
{
    public class ItemIO : IItemIO
    {
        public List<ItemListAllModel> GetAllItemDescriptions()
        {
            throw new NotImplementedException();
        }

        public object GetItemByItemIdAndStoreId(int selectedItemId, int selectedStoreId)
        {
            throw new NotImplementedException();
        }
    }
}
