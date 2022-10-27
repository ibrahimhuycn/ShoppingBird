using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IUnitsIO
    {
        List<UnitsModel> LoadAll();
        void Save(UnitsModel e);
    }
}
