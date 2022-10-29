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

        public async Task<PriceListModel> UpdateStorePriceAsync(int priceListId, string barcode, decimal retailPrice)
        {
            var storedProcedure = "[dbo].[usp_UpdateStorePriceAndBarcodeById]";
            var parameter = new
            {
                PriceListId = priceListId, Barcode = barcode, RetailPrice = retailPrice
            };

            var updated = await _dataAccessBase.SelectInsertOrUpdateAsync<PriceListModel, dynamic>
                (storedProcedure, parameter);
            return updated;
        }

        public async Task<PriceListModel> InsertPriceListRecordAsync(int itemId, string barcode, int storeId, decimal retailPrice, int unitId)
        {
            var storedProcedure = "[dbo].[usp_InsertItemPrice]";
            var parameters = new
            {
                ItemId = itemId,
                Barcode = barcode,
                StoreId = storeId,
                RetailPrice = retailPrice,
                UnitId = unitId,
                UpdatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var inserted = await _dataAccessBase.SelectInsertOrUpdateAsync<PriceListModel,dynamic>(storedProcedure, parameters);
            return inserted;
        }
    }
}
