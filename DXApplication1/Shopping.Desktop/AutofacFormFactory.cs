using Autofac;
using System.Windows.Forms;
using System;

namespace ShoppingBird.Desktop
{
    public class AutofacFormFactory : IFormFactory
    {
        private readonly ILifetimeScope _currentScope;

        public AutofacFormFactory(ILifetimeScope currentScope)
        {
            this._currentScope = currentScope;
        }

        public Form CreateForm(Type formType)
        {
            // begin a new lifetime scope for each form instance
            var scope = _currentScope.BeginLifetimeScope();

            var form = (Form)scope.Resolve(formType);

            form.Disposed += (s, e) =>
            {
                // finish the scope when the form is disposed (closed)
                scope.Dispose();
            };

            return form;
        }
    }
}