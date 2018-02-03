using System;
using System.Linq;
using System.Linq.Expressions;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class WeiXinPrizeUserRepository : RepositoryBase<Tbl_WeiXinPrizeUser>
    {
        public WeiXinPrizeUserRepository(TicketDbContext dbContext) : base(dbContext)
        {

        }
    }
}
