using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class MsgRepository : RepositoryBase<Tbl_Msg>
    {
        public MsgRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
