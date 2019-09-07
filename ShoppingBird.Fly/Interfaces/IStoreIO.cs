using ShoppingBird.Fly.DbModels;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStoreIO
    {
        IList<Store> LoadAll();
        int SaveStore(Store e);
    }
}
