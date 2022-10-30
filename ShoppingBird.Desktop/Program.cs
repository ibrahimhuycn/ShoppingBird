using Autofac;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ShoppingBird.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app  = scope.Resolve<IShoppingBirdApplication>();
                FormFactory.Use(container.Resolve<IFormFactory>());
                app.Run();
            }
        }
    }
}
