using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class MemberTypeRepository : RepositoryBase<Tbl_Member_Type>
    {
        public MemberTypeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
