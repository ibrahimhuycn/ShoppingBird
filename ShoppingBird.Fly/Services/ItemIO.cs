using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Services
{
    public class ItemIO : IItemIO
    {
        private readonly IDataAccessBase _dataAccessBase;

        public ItemIO(IDataAccessBase dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }
        public async Task<List<ItemListAllModel>> GetAllItemDescriptionsAsync()
        {
            var storedProcedure = "[dbo].[usp_GetAllItemDescriptionsWithIdAndBarcode]";
            var data = await _dataAccessBase.LoadDataAsync<ItemListAllModel>(storedProcedure);
            return data;
        }

        public async Task<CartItemModel> GetItemByItemIdAndStoreIdAsync(int itemId, int storeId)
        {
            var storedProcedure = "[dbo].[usp_SearchItemByItemIdAndStoreId]";
            var parameter = new {ItemId = itemId, StoreId = storeId};
            var data = await _dataAccessBase.LoadDataWithParameterAsync<CartItemModel, dynamic>(storedProcedure, parameter);
            return data.FirstOrDefault();
        }
    }
}
