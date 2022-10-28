using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IPriceListIO
    {
        Task<List<PriceListModel>> GetAllPricesForAllStoresWithUnitsAsync();
    }
}
