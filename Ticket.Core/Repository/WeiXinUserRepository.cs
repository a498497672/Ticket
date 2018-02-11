using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinUserRepository : RepositoryBase<Tbl_WeiXinUser>
    {
        public WeiXinUserRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
