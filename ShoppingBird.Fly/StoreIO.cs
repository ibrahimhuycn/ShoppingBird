﻿using ShoppingBird.Fly.Models;
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

        public IList<Store> LoadAll()
        {
            List<Store> StoreList = new List<Store>();

            string CnxString = Helper.GetConnectionString("ShoppingBirdData");
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<Store>("usp_GetAllStores", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int SaveStore(Store e)
        {
            throw new NotImplementedException();
        }
    }
}
