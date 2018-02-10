using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class OrderRefundDetailRepository : RepositoryBase<Tbl_OrderRefundDetail>
    {
        public OrderRefundDetailRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
