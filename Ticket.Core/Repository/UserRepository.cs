using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class UserRepository : RepositoryBase<Tbl_User>
    {
        public UserRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
