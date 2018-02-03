using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinUserRepository : RepositoryBase<Tbl_WeiXin_User>
    {
        public WeiXinUserRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
