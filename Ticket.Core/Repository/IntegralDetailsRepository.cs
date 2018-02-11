using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class IntegralDetailsRepository : RepositoryBase<Tbl_IntegralDetails>
    {
        public IntegralDetailsRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
