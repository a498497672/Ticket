using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Module = Autofac.Module;

namespace Ticket.Platform.AutoFac
{
    public class PlatformAutofacModule : Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //注册当前程序集下的所有Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}