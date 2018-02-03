using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class OrderDetailRepository : RepositoryBase<Tbl_OrderDetail>
    {
        public OrderDetailRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
