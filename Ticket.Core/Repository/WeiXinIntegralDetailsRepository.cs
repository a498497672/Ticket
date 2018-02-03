using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinIntegralDetailsRepository : RepositoryBase<Tbl_WeiXinIntegralDetails>
    {
        public WeiXinIntegralDetailsRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
