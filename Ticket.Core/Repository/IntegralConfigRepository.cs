using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class IntegralConfigRepository : RepositoryBase<Tbl_WeiXinIntegralConfig>
    {
        public IntegralConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
