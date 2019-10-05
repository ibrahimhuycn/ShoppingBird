using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ShoppingBird.Fly.DataAccess
{
    public class Helper
    {
        public static string GetConnectionString(string CnxString)
        {
            string ConnectionString;
            //ConnectionString = @"Server = (LocalDb)\MSSQLLocalDB; Database = pShoppingbirdData;";
            ConnectionString = @"Server = (LocalDb)\MSSQLLocalDB; Database = ShoppingbirdData;";
            return ConnectionString;
        }
    }
}
