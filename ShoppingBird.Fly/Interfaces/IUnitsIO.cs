using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IUnitsIO
    {
        Task<UnitsModel> InsertUnitAsync(string unit, string description);
        Task<List<UnitsModel>> LoadAllUnitsAsync();
        Task<UnitsModel> UpdateUnitAsync(UnitsModel e);
    }
}
