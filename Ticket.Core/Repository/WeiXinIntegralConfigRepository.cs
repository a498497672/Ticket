using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinIntegralConfigRepository : RepositoryBase<Tbl_WeiXinIntegralConfig>
    {
        public WeiXinIntegralConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
