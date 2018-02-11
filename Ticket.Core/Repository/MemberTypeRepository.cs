using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class MemberTypeRepository : RepositoryBase<Tbl_MemberType>
    {
        public MemberTypeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
