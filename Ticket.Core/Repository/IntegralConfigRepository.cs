using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class IntegralConfigRepository : RepositoryBase<Tbl_IntegralConfig>
    {
        public IntegralConfigRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
