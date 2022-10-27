using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStoreIO
    {
        Task<List<StoreModel>> GetAllStoresAsync();
        StoreModel SaveStore(StoreModel e);
        StoreModel UpdateStore(StoreModel e);
    }
}
