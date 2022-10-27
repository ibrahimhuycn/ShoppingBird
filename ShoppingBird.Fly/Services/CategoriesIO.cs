using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingBird.Fly.Services
{
    public class CategoriesIO : ICategoriesIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");

        public void SaveCategory(ItemCategory e)
        {

        }

        public List<ItemCategory> LoadAll()
        {
            List<ItemCategory> CategoryList = new List<ItemCategory>();
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<ItemCategory>("usp_GetAllCategories", commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}
