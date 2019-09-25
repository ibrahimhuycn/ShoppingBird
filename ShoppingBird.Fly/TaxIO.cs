using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShoppingBird.Fly
{
    public class TaxIO : ITaxIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");
        public void SaveTax(Tax e)
        {

        }


        public List<Tax> GetAllTax()
        {
            List<Tax> TaxList = new List<Tax>();
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<Tax>("usp_GetAllTax", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
