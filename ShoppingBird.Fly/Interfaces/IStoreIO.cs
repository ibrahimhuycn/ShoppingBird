using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStoreIO
    {
        Task<List<StoreModel>> GetAllStoresAsync();
        Task<StoreModel> InsertStoreAsync(string storeName);
        Task<StoreModel> UpdateStoreAsync(StoreModel e);
    }
}
