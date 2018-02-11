using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class PrizeRepository : RepositoryBase<Tbl_Prize>
    {
        public PrizeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
