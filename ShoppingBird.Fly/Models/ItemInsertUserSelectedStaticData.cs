using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    /// <summary>
    /// This model encapsulates all the models required for new item / item details insert into the database
    /// </summary>
    public class ItemInsertUserSelectedStaticData : IItemInsertUserSelectedStaticData
    {

        private ItemCategory _category;
        private Store _store;
        private ItemCategory _subCategory;
        private Tax _tax;
        private Units _unit;

        /// <summary>
        /// Return a populated object of type ItemInsertUserSelectedStaticData
        /// </summary>
        /// <param name="store">An instance of the Store model</param>
        /// <param name="tax">An instance of Tax model</param>
        /// <param name="category">An instance of ItemCategory model</param>
        /// <param name="subCategory">An instance of ItemCategory model as sub category</param>
        /// <param name="unit">An instance of units model</param>
        public ItemInsertUserSelectedStaticData Initialise(Store store, Tax tax, ItemCategory category, ItemCategory subCategory, Units unit)
        {
            this._store = store;
            this._tax = tax;
            this._category = category;
            this._subCategory = subCategory;
            this._unit = unit;

            return this;
        }

        public ItemCategory Category
        {
            get
            {
                return _category;
            }
        }
        public Store Store
        {
            get
            {
                return _store;
            }
        }
        public ItemCategory SubCategory
        {
            get
            {
                return _subCategory;
            }
        }
        public Tax Tax
        {
            get
            {
                return _tax;
            }
        }
        public Units Unit
        {
            get
            {
                return _unit;
            }
        }
    }

}
