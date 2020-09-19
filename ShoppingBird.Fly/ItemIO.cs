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
    /// <summary>
    /// Handles reading and saving item and item price data into price lists.
    /// </summary>
    public class ItemIO : IItemIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");

        /// <summary>
        /// Saves a new item and its price data or an existing items price data to the database.
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Returns 0 on successful insertion</returns>
        public int SaveItem(ItemInsertDataArgs e)
        {
            //Try to read itemId from database. If this is found.., PriceData may need to be inserted.
            e.Item.Id = SelectItemByDescription(e.Item.Description);

            //Try reading the price for the specified item for the specified store from the database
            var SearchResult = SearchByDescriptionAndStore(new ItemSearchTerms(e.Item.Description, e.PriceData.Store.Id, false));

            //If the item is not in the database the error message will have a value because it could not find any data for the search
            if (SearchResult.ErrorMessage is null)
            {
                throw new Exception($"Item (Barcode): {SearchResult.Description} ({e.PriceData.Barcode}){Environment.NewLine}" +
                    $"Store: {e.PriceData.Store.Name}{Environment.NewLine}" +
                    "The item and price data for the store is already in the database!");
            }

            //If ItemId returned !=0 , It means that the item is present in the database and returned the Id
            //Note: The following lines will not be executed if both the item it's price data is present on DB.
            if (e.Item.Id == 0)
            {
                //Insert item
                e.Item.Id = InsertItemReturnId(e.Item);
                //Insert price data
                SaveItemPrice(e.PriceData);
            }
            else
            {
                //Insert PriceData for the Item
                SaveItemPrice(e.PriceData);
            }


            return 0;
        }

        /// <summary>
        /// Searches items by barcode/description and the selected store.
        /// </summary>
        /// <param name="e">An instance of ItemSearchTerms passed as parameters</param>
        /// <returns></returns>
        public ItemSearchResultModel SearchItem(ItemSearchTerms e)
        {
            switch (e.searchBy)
            {
                case SearchBy.Barcode:
                    return SearchByBarcodeAndStore(e);
                case SearchBy.Description:
                    return SearchByDescriptionAndStore(e);
                default:
                    throw new ArgumentOutOfRangeException("please pass in a barcode or item description for searching");
            }

        }

        /// <summary>
        /// Returns the descriptions of all items to be displayed in the invoice search drop down
        /// </summary>
        /// <returns></returns>
        public List<ItemListAllModel> GetAllItemDescriptions()
        {
            List<ItemListAllModel> StoreList = new List<ItemListAllModel>();

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<ItemListAllModel>("usp_GetAllItemDescriptionsWithId", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Searches all prices for the item in all stores provided the item description.
        /// </summary>
        /// <param name="itemDescription">The item name.</param>
        /// <returns></returns>
        public List<SearchResultsAllPriceDataForItemModel> SearchAllPriceDataForItem(string itemDescription)
        {
            var Item = new { ItemDescription = itemDescription };

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<SearchResultsAllPriceDataForItemModel>("usp_GetAllPricesDataForItem", Item,
                     commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// This function returns an instance of a class ItemInsertAssistDataModel which
        /// contains UnitId, Category, SubCategory and Tax which is needed for item insert. This is implemented 
        /// to make it easier for the end user to enter item data in Item Settings page.
        /// </summary>
        /// <param name="barcode">The item barcode</param>
        /// <param name="storeId">The store ID from which the data is to be fetched.</param>
        public ItemInsertAssistDataModel GetInsertAssistData(string barcode, int storeId)
        {
            var Item = new { Barcode = barcode, StoreId = storeId };

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                try
                {
                    return cnx.Query<ItemInsertAssistDataModel>("usp_GetItemCatDataAndUnitWithBarcodeAndStore", Item, 
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    return new ItemInsertAssistDataModel { ErrorMessage = ex.Message };
                }
            }
        }

        /// <summary>
        /// Search ItemId by  its description
        /// </summary>
        /// <param name="itemDescription">The item description</param>
        /// <returns>Returns 0 if not found, else returns ItemId</returns>
        private int SelectItemByDescription(string itemDescription)
        {
            int itemId = 0;

            var Item = new { Description = itemDescription };
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var searchResult = cnx.Query<dynamic>("usp_SearchItemIdByItemDescription", Item,
                                                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (searchResult != null)
                {
                    itemId = searchResult.Id;
                }

            }

            return itemId;
        }

        /// <summary>
        /// Inserts a record to dbo.Item
        /// </summary>
        /// <param name="item">Instance of class with data to insert</param>
        /// <returns>Returns inserted records ItemId</returns>
        private int InsertItemReturnId(Item item)
        {
            int itemId = 0;
            var newItem = new
            {
                Description = item.Description,
                CategoryId = item.Category.Id,
                SubCategoryId = item.SubCategory.Id
            };

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var searchResult = cnx.QuerySingle<dynamic>("usp_InsertItemReturnInsertedId", newItem,
                                                    commandType: CommandType.StoredProcedure);
                if (searchResult != null)
                {
                    itemId = searchResult.Id;
                }
            }
            return itemId;
        }

        /// <summary>
        /// Save Price data for the specified store
        /// </summary>
        /// <param name="item"></param>
        private void SaveItemPrice(ItemPriceData item)
        {
            var ItemPriceData = new
            {
                ItemId = item.Item.Id,
                Barcode = item.Barcode,
                TaxId = item.Tax.Id,
                StoreId = item.Store.Id,
                RetailPrice = item.RetailPrice,
                UnitId = item.Unit.Id,
                UpdatedAt = DateTime.Today,
                CreatedAt = DateTime.Today
            };

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                cnx.Execute("usp_InsertItemPrice", ItemPriceData,
                                                   commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Search for item price data by barcode and store
        /// </summary>
        /// <param name="e">Input data for search</param>
        /// <returns></returns>
        private ItemSearchResultModel SearchByBarcodeAndStore(ItemSearchTerms e)
        {
            ItemSearchResultModel SearhResult;
            var barcodeParameters = new { Barcode = e.Barcode, StoreId = e.Store.Id };
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                SearhResult = cnx.Query<ItemSearchResultModel>("usp_SearchItemByBarcodeAndStore", barcodeParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            if (SearhResult == null) { SearhResult = new ItemSearchResultModel { ErrorMessage = "PriceDataNotFoundForStore" }; }
            return SearhResult;

        }

        /// <summary>
        /// Search for item price data by description and store
        /// </summary>
        /// <param name="e">Input data for search</param>
        /// <returns></returns>
        private ItemSearchResultModel SearchByDescriptionAndStore(ItemSearchTerms e)
        {
            ItemSearchResultModel SearhResult;
            var descriptionsParameters = new { Description = e.Item.Description, StoreId = e.Store.Id };

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                SearhResult = cnx.Query<ItemSearchResultModel>("usp_SearchItemByDescriptionAndStore", descriptionsParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            if (SearhResult == null)
            {
                SearhResult = new ItemSearchResultModel { ErrorMessage = "Item does not exist in the specified store." };
            }
            return SearhResult;
        }

        public ItemDataModel GetItemDataByBarcode(string barcode)
        {
            var Item = new { Barcode = barcode};

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                try
                {
                    return cnx.Query<ItemDataModel>("[dbo].[usp_GetItemDataWithBarcode]", Item,
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
