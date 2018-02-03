using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class SoundWallRepository : RepositoryBase<Tbl_SoundWall>
    {
        public SoundWallRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
