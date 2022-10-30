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
        Task<PriceListModel> InsertPriceListRecordAsync(int itemId, string barcode, int storeId, decimal retailPrice, int unitId);
        Task<PriceListModel> UpdateStorePriceAsync(int priceListId, string barcode, decimal retailPrice);
    }
}
