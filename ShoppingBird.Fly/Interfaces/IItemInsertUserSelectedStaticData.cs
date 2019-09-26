using System;
using ShoppingBird.Fly.Models;

namespace ShoppingBird.Fly.Interfaces
{
    public interface IItemInsertUserSelectedStaticData
    {
        /// <summary>
        /// Return a populated object of type ItemInsertUserSelectedStaticData
        /// </summary>
        /// <param name="store">An instance of the Store model</param>
        /// <param name="tax">An instance of Tax model</param>
        /// <param name="category">An instance of ItemCategory model</param>
        /// <param name="subCategory">An instance of ItemCategory model as sub category</param>
        /// <param name="unit">An instance of units model</param>
        ItemInsertUserSelectedStaticData Initialise(Store store, Tax tax, ItemCategory category, ItemCategory subCategory, Units unit);

        ItemCategory Category { get; }
        Store Store { get; }
        ItemCategory SubCategory { get; }
        Tax Tax { get; }
        Units Unit { get; }
    }
}
