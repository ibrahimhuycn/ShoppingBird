using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IUnitsIO
    {
        List<Units> LoadAll();
        void Save(Units e);
    }
}
