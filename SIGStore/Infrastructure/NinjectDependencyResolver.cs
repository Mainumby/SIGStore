﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using SIG18.Domain.Entities;
using SIG18.Domain.Abstract;
using SIG18.Domain.Concrete;
using System.Web.Mvc;
using System.Configuration;

namespace SIGStore.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();


        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);

        }

        private void AddBindings()
        {
            //put bidings here
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new  Product {Name = "Football", Price =25 },
            //    new Product {Name = "Surf board", Price = 179 },
            //    new Product { Name = "Running Shoes" , Price = 95 }
            //});
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);


            kernel.Bind<IProductsRepository>().To<EFProductRepository>();



            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }

    }
}