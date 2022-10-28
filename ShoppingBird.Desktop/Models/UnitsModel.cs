using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.Models
{
    public class UnitsModel : NotifyBase
    {
        private int _id;
        private string _unit;
        private string _description;

        public int Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Unit
        {
            get => _unit; set
            {
                _unit = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => _description; set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
