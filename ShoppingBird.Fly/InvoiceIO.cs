using Dapper;
using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingBird.Fly
{
    public class InvoiceIO : IInvoiceIO
    {
        
        public int SaveInvoice(NewInvoice e)
        {
            int Insert_InvoiceId = 0;
            int returnvalue = 1;
            string CnxString = Helper.GetConnectionString("ShoppingBirdData");

            try
            {
                //step one: insert invoice 
                using (IDbConnection cnx = new SqlConnection(CnxString))
                {
                    Insert_InvoiceId = cnx.Execute("usp_InsertInvoice", e.Invoice, commandType: CommandType.StoredProcedure);
                }

                //step two: insert InvoiceDetails
                if (Insert_InvoiceId == 0) { throw new Exception("The invoice insert failed. Aborted insert of invoice details."); }

                foreach (var item in e.InvoiceDetails)
                {
                    item.InvoiceId = Insert_InvoiceId;
                }
                using (IDbConnection cnx = new SqlConnection(CnxString))
                {
                    cnx.Execute("usp_InsertInvoiceDetails", e.InvoiceDetails, commandType: CommandType.StoredProcedure);
                }

                returnvalue = 0;
            }
            catch (Exception)
            {

                throw;
            }



            return returnvalue;
        }

        IStaticInvoiceData IInvoiceIO.LoadStaticData()
        {
            throw new NotImplementedException();
        }
    }
}
