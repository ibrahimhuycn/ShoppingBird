using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class StoreModel : NotifyBase
    {
        private int _id;
        private string _name;

        public int Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
}
