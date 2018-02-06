using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class PrizeRepository : RepositoryBase<Tbl_WeiXinPrize>
    {
        public PrizeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
