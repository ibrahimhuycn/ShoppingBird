using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStoreIO
    {
        IList<Store> GetAllStores();
        Store SaveStore(Store e);
        Store UpdateStore(Store e);
    }
}
