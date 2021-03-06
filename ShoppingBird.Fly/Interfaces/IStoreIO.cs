﻿using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IStoreIO
    {
        IList<Store> GetAllStores();
        int SaveStore(Store e);
    }
}
