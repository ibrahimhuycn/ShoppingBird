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
            string a = @"Server = (LocalDb)\MSSQLLocalDB; Database = ShoppingbirdData; ";
            return a;
        }
    }
}
