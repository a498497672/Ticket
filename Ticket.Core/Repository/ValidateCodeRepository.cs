using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class ValidateCodeRepository : RepositoryBase<Tbl_ValidateCode>
    {
        public ValidateCodeRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}

