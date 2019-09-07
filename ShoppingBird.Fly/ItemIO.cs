using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingBird.Fly
{
    public class ItemIO : IItemIO
    {
        public int SaveItem(NewItem e)
        {
            throw new NotImplementedException();
        }

        public ItemSearchResultModel SearchItem(ItemSearchTerms e)
        {
            string CnxString = Helper.GetConnectionString("ShoppingBirdData");
            
            switch (e.searchBy)
            {
                case SearchBy.Barcode:
                    ItemSearchResultModel SearhResult;
                    var barcodeParameters = new { Barcode = e.Barcode, StoreId = e.Store.Id };
                    using (IDbConnection cnx = new SqlConnection(CnxString))
                    {
                        SearhResult = cnx.Query<ItemSearchResultModel>("usp_SearchItemByBarcodeAndStore", barcodeParameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    return SearhResult;

                case SearchBy.Description:
                   
                   var descriptionsParameters = new { Description = e.Item.Description, StoreId = e.Store.Id };

                    using (IDbConnection cnx = new SqlConnection(CnxString))
                    {
                        SearhResult = cnx.Query<ItemSearchResultModel>("usp_SearchItemByDescriptionAndStore", descriptionsParameters,
                            commandType: CommandType.StoredProcedure).FirstOrDefault();
                    }
                    return SearhResult;
                default:
                    throw new ArgumentOutOfRangeException("please pass in a barcode or item description for searching");
            }

        }

        public List<ItemListAllModel> GetAllItemDescriptions()
        {
            List<ItemListAllModel> StoreList = new List<ItemListAllModel>();

            string CnxString = Helper.GetConnectionString("ShoppingBirdData");
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<ItemListAllModel>("usp_GetAllItemDescriptionsWithId", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
