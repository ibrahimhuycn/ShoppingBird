﻿using Autofac;
using AutoMapper;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Fly.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(config => 
            {
                config.CreateMap<ItemListAllModel, ShoppingBird.Fly.Models.ItemListAllModel>().ReverseMap();
                config.CreateMap<StoreModel, ShoppingBird.Fly.Models.StoreModel>().ReverseMap();
                config.CreateMap<CartItemModel, ShoppingBird.Fly.Models.CartItemModel>().ReverseMap();
                config.CreateMap<NewInvoiceModel, ShoppingBird.Fly.Models.NewInvoiceModel>().ReverseMap();
                config.CreateMap<InvoiceModel, ShoppingBird.Fly.Models.InvoiceModel>().ReverseMap();
                config.CreateMap<TransactionHistoryModel, ShoppingBird.Fly.Models.TransactionHistoryModel>().ReverseMap();
                config.CreateMap<UnitsModel, ShoppingBird.Fly.Models.UnitsModel>().ReverseMap();
                config.CreateMap<PriceListModel, ShoppingBird.Fly.Models.PriceListModel>().ReverseMap();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion

            builder.RegisterType<ShoppingBirdApplication>().As<IShoppingBirdApplication>();
            builder.RegisterType<AutofacFormFactory>().As<IFormFactory>();

            #region Register Data access services
            builder.RegisterType<DataAccessBase>().As<IDataAccessBase>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.Load("ShoppingBird.Fly"))
                .Where(t=> t.Namespace.Contains("Services") || t.Namespace.Contains("Interfaces"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I"+ t.Name));
            #endregion

            #region Register ViewModels
            builder.RegisterAssemblyTypes(Assembly.Load("ShoppingBird.Desktop"))
                .Where(t => t.Namespace.Contains("ViewModels"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            #endregion

            #region Register Views
            builder.RegisterAssemblyTypes(Assembly.Load("ShoppingBird.Desktop"))
                .Where(t => t.Namespace.Contains("Views"));
            #endregion

            return builder.Build();
        }
    }
}
