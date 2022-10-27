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

        public StoreModel SaveStore(StoreModel e)
        {
            throw new NotImplementedException();
        }

        public StoreModel UpdateStore(StoreModel e)
        {
            throw new NotImplementedException();
        }
    }
}