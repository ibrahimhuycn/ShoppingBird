using ShoppingBird.Fly.Models;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemIO
    {
        int SaveItem(NewItem e);
        PriceList SearchItem(ItemSearchTerms e);
        AllDescriptionsItems GetAllItemDescriptions();
    }
}
