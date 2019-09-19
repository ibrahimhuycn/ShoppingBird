using ShoppingBird.Fly.Models;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Interfaces
{
    public interface ICategoriesIO
    {
        List<ItemCategory> LoadAll();
        void SaveCategory(ItemCategory e);
    }
}
