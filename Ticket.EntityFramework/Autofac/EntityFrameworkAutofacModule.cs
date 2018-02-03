using Autofac;

namespace Ticket.EntityFramework.Autofac
{
    public class EntityFrameworkAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TicketDbContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
