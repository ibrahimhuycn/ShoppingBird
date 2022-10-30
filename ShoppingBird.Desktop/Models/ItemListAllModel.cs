using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class ItemListAllModel : NotifyBase
    {
        private int _id;
        private string _item;

        public int Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Item
        {
            get => _item; set
            {
                _item = value;
                OnPropertyChanged();
            }
        }
    }
}
