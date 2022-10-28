using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Services
{
    public class PriceListIO: IPriceListIO
    {
        private readonly IDataAccessBase _dataAccessBase;

        public PriceListIO(IDataAccessBase dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }

        public async Task<List<PriceListModel>> GetAllPricesForAllStoresWithUnitsAsync()
        {
            var storedProcedure = "[dbo].[usp_GetAllPriceListsForAllStoresWithUnits]";
            var priceLists = await _dataAccessBase.LoadDataAsync<PriceListModel>(storedProcedure);
            return priceLists;
        }
    }
}
