using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinPrizeRepository : RepositoryBase<Tbl_WeiXinPrize>
    {
        public WeiXinPrizeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
