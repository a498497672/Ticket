using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class TicketRepository : RepositoryBase<Tbl_Ticket>
    {
        public TicketRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
