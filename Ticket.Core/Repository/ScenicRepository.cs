using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class ScenicRepository : RepositoryBase<Tbl_Scenic>
    {
        public ScenicRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
