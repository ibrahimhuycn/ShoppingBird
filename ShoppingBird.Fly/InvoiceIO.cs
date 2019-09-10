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
            int returnvalue = 1;
            int InsertedInvoiceId = 0;
            string CnxString = Helper.GetConnectionString("ShoppingBirdData");

            //BUG: Invoice can be inserted without details due to an exception on Details insert. Invoice insert does not rollback
          
            try
            {
                //step one: insert invoice 
                using (IDbConnection cnx = new SqlConnection(CnxString))
                {
                   var result = cnx.QuerySingle<dynamic>("usp_InsertInvoice", e.Invoice, commandType: CommandType.StoredProcedure);
                    InsertedInvoiceId = Convert.ToInt32(result.Inserted_InvoiceId);
                }

                //step two: insert InvoiceDetails
                if (InsertedInvoiceId == 0) { throw new Exception("The invoice insert failed. Aborted insert of invoice details."); }

                foreach (var item in e.InvoiceDetails)
                {
                    item.InvoiceId = InsertedInvoiceId;
                    using (IDbConnection cnx = new SqlConnection(CnxString))
                    {
                        cnx.Execute("usp_InsertInvoiceDetails", item, commandType: CommandType.StoredProcedure);
                    }
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
