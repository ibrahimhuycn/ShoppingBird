using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;


namespace ShoppingBird.Fly
{
    public class ItemIO : IItemIO
    {
        public int SaveItem(NewItem e)
        {
            throw new NotImplementedException();
        }

        public PriceList SearchItem(ItemSearchTerms e)
        {
            switch (e.searchBy)
            {
                //Search by barcode
                case SearchBy.Barcode:
                    break;
                    //Search by description
                case SearchBy.Description:
                    break;
                default:
                    break;
            }

            throw new NotImplementedException();
        }
    }
}
