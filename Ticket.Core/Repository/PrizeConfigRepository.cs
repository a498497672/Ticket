using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class PrizeConfigRepository : RepositoryBase<Tbl_WeiXinPrizeConfig>
    {
        public PrizeConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
