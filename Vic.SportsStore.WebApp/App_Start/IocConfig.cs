﻿using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.WebApp
{
    public class IoCConfig
    {
        public static void ConfigIoC()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterControllers(typeof(MvcApplication).Assembly)//auto register all the controller in this assembly
                .PropertiesAutowired();


            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock
            //    .Setup(m => m.Products)
            //    .Returns(new List<Product>
            //    {
            //        new Product { Name = "Football", Price = 25 },
            //        new Product { Name = "Surf board", Price = 179 },
            //        new Product { Name = "Running shoes", Price = 95 }
            //    });

            //IProductsRepository products = new InMemoryProductsRepository();

            //builder.RegisterInstance<IProductsRepository>(mock.Object);
            //builder.RegisterInstance<IProductsRepository>(new InMemoryProductsRepository())
            //       .PropertiesAutowired();//auto register all the Properties in this assembly

            builder.RegisterInstance<IProductsRepository>(new EFProductRepository())
                 .PropertiesAutowired();//auto register all the Properties in this assembly using EFProductRepository

            builder.RegisterInstance<EFDbContext>(new EFDbContext())
               .PropertiesAutowired();//auto register all the Properties in this assembly using EFProductRepository

            builder
                .RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()))
              .PropertiesAutowired();//auto register all the Properties in this assembly using EFProductRepository


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}