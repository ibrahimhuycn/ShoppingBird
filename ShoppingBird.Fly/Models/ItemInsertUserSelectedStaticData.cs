using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class ItemInsertUserSelectedStaticData
    {
        public ItemInsertUserSelectedStaticData(Store store, Tax tax, ItemCategory category, ItemCategory subCategory, Units unit)
        {
            this._store = store;
            this._tax = tax;
            this._cat = category;
            this._subCat = subCategory;
            this._unit = unit;
        }
        private Store _store;
        public Store Store
        {
            get
            {
                return _store;
            }
        }

        private Tax _tax;
        public Tax Tax
        {
            get
            {
                return _tax;
            }
        }

        private ItemCategory _cat;
        public ItemCategory Cat
        {
            get
            {
                return _cat;
            }
        }

        private ItemCategory _subCat;
        public ItemCategory SubCat
        {
            get
            {
                return _subCat;
            }
        }

        private Units _unit;
        public Units Unit
        {
            get
            {
                return _unit;
            }
        }
    }

}
