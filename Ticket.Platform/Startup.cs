using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Owin;
using System.Web.Mvc;
using Ticket.EntityFramework.Autofac;
using Ticket.Platform.AutoFac;

namespace Ticket.Platform
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAutofac(app);          
            //ConfigureAutoMapper();
        }

        private void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterModule(new EntityFrameworkAutofacModule());
            builder.RegisterModule(new PlatformAutofacModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}