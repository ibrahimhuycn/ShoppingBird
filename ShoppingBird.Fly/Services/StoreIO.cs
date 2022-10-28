using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Services
{
    public class StoreIO : IStoreIO
    {
        private readonly IDataAccessBase _dataAccessBase;

        public StoreIO(IDataAccessBase dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }
        public async Task<List<StoreModel>> GetAllStoresAsync()
        {
            var storedProcedure = "[dbo].[usp_GetAllStores]";
            var stores = await _dataAccessBase.LoadDataAsync<StoreModel>(storedProcedure);
            return stores;
        }

        public async Task<StoreModel> UpdateStoreAsync(StoreModel e)
        {
            var storedProcedure = "[dbo].[usp_UpdateStoreAndReturnInserted]";
            var parameters = new {Id = e.Id, StoreName = e.Name};
            var updated = await _dataAccessBase.SelectInsertOrUpdateAsync<StoreModel, dynamic>(storedProcedure, parameters);
            return updated;
        }

        public async Task<StoreModel> InsertStoreAsync(string storeName)
        {
            var storedProcedure = "[dbo].[usp_InsertStoreAndReturnInserted]";
            var parameters = new
            {
                StoreName = storeName
            };
            var insertedStore = await _dataAccessBase.SelectInsertOrUpdateAsync<StoreModel, dynamic>(storedProcedure, parameters);
            return insertedStore;
        }
    }
}