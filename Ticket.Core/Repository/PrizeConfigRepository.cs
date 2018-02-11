using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class PrizeConfigRepository : RepositoryBase<Tbl_PrizeConfig>
    {
        public PrizeConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
