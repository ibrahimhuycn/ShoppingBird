using System;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    public interface IFormFactory
    {
        Form CreateForm(Type formType);
    }
}
