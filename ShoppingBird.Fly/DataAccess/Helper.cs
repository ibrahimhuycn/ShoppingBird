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
            ConnectionString = @"Server=192.168.100.4;Database=pShoppingBirdData;User Id=sa;Password=Bismillah.123!;";
            //ConnectionString = @"Server = (LocalDb)\MSSQLLocalDB; Database = ShoppingbirdData;";
            //ConnectionString = @"Server=tcp:shoppingbird.database.windows.net,1433;Initial Catalog=pShoppingBirdData;Persist Security Info=False;User ID=swatincadmin;Password=Bismillah.123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            return ConnectionString;
        }
    }
}