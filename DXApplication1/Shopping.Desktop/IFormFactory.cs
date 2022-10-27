using System;
using System.Windows.Forms;

namespace Shopping.Desktop
{
    public interface IFormFactory
    {
        Form CreateForm(Type formType);
    }
}
