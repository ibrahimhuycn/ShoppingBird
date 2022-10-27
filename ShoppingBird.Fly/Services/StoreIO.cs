using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingBird.Fly.Services
{
    public class StoreIO : IStoreIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");
        public IList<Store> GetAllStores()
        {
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var stores = cnx.Query<Store>("usp_GetAllStores", commandType: CommandType.StoredProcedure).ToList();
                return stores;
            }
        }

        public Store SaveStore(Store e)
        {
            //[dbo].[usp_InsertStoreAndReturnInserted]
            var newStore = new { StoreName = e.Name, IsTaxInclusive = e.IsTaxInclusive };
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var inserted = cnx.QueryFirstOrDefault<Store>("[dbo].[usp_InsertStoreAndReturnInserted]", newStore,
                                                    commandType: CommandType.StoredProcedure);
                return inserted;
            }

        }

        public Store UpdateStore(Store e)
        {
            var updatedStore = new { Id = e.Id, StoreName = e.Name, IsTaxInclusive = e.IsTaxInclusive };
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var inserted = cnx.QueryFirstOrDefault<Store>("[dbo].[usp_UpdateStoreAndReturnInserted]", updatedStore,
                                                    commandType: CommandType.StoredProcedure);
                return inserted;
            }
        }
    }
}
