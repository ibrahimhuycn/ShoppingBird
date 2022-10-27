using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Models;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShoppingBird.Fly.Services
{
    public class UnitsIO : IUnitsIO
    {
        private readonly string CnxString = Helper.GetConnectionString("ShoppingBirdData");

        public void Save(Units e)
        {

        }

        public List<Units> LoadAll()
        {
            List<Units> CategoryList = new List<Units>();
            using (IDbConnection cnx = new SqlConnection(CnxString))
            {
                return cnx.Query<Units>("usp_GetAllUnits", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
