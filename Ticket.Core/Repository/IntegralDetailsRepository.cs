using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class IntegralDetailsRepository : RepositoryBase<Tbl_WeiXinIntegralDetails>
    {
        public IntegralDetailsRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
