using ShoppingBird.Fly.Models;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using System.Linq;
using System.Data.SqlClient;

namespace ShoppingBird.Fly
{
    public class StoreIO : IStoreIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");
        public IList<Store> GetAllStores()
        {
            List<Store> StoreList = new List<Store>();

            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                var stores = cnx.Query<Store>("usp_GetAllStores", commandType: CommandType.StoredProcedure).ToList();
                return stores;
            }
        }

        public int SaveStore(Store e)
        {
            throw new NotImplementedException();
        }
    }
}
