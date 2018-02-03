using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class OrderRepository : RepositoryBase<Tbl_Order>
    {
        public OrderRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
