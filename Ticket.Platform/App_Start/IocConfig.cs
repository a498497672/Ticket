using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticket.Platform.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<EFProductRepository>().As<IProductRepository>();

            ////autofac 注册依赖
            //IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}