using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinPrizeConfigRepository : RepositoryBase<Tbl_WeiXinPrizeConfig>
    {
        public WeiXinPrizeConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
