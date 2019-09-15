using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;

namespace ShoppingBird.Fly
{
    public class InvoiceIO : IInvoiceIO
    {

        public int SaveInvoice(NewInvoice e)
        {
            int returnvalue = 1;
            int InsertedInvoiceId = 0;

            //BUG: Invoice can be inserted without details due to an exception on Details insert. Invoice insert does not rollback

            using (SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    //step one: insert invoice 
                    sql.StartTransaction("ShoppingBirdData");
                    var result = sql.SaveDataInTransactionQuerySingle("usp_InsertInvoice", e.Invoice);
                    InsertedInvoiceId = Convert.ToInt32(result.Inserted_InvoiceId);

                    //step two: insert InvoiceDetails
                    if (InsertedInvoiceId == 0) { throw new Exception("The invoice insert failed. Aborted insert of invoice details."); }
                    foreach (var item in e.InvoiceDetails)
                    {
                        item.InvoiceId = InsertedInvoiceId;
                        sql.SaveDataInTransactionExecute("usp_InsertInvoiceDetails", item);
                    }

                    returnvalue = 0;
                }
                catch (Exception ex)
                {

                    sql.RollbackTransaction();
                    throw new Exception(ex.Message);
                    //throw;
                }

                return returnvalue;
            }

        }

        IStaticInvoiceData IInvoiceIO.LoadStaticData()
        {
            throw new NotImplementedException();
        }
    }
}
