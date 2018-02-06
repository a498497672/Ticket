using System;
using System.Linq;
using System.Linq.Expressions;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class PrizeUserRepository : RepositoryBase<Tbl_WeiXinPrizeUser>
    {
        public PrizeUserRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }
    }
}
