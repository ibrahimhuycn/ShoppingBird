using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    public static class FormFactory
    {
        private static IFormFactory _factory;

        public static void Use(IFormFactory factory)
        {
            if (FormFactory._factory != null)
            {
                throw new InvalidOperationException(@"Form factory has been already set up.");
            }

            FormFactory._factory = factory;
        }

        public static Form Create(Type formType)
        {
            if (_factory == null)
            {
                throw new InvalidOperationException(@"Form factory has not been set up. Call the 'Use' method to inject an IFormFactory instance.");
            }

            return _factory.CreateForm(formType);
        }

        public static T Create<T>() where T : Form
        {
            return (T)Create(typeof(T));
        }
    }
}
