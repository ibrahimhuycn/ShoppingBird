using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Desktop
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ShoppingBirdApplication>().As<IShoppingBirdApplication>();

            builder.RegisterAssemblyTypes(Assembly.Load("ShoppingBird.Fly"))
                .Where(t=> t.Namespace.Contains("Services") || t.Namespace.Contains("Interfaces"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I"+ t.Name));

            return builder.Build();
        }
    }
}
