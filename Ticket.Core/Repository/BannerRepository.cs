using System;
using System.Linq;
using System.Linq.Expressions;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;

namespace Ticket.Core.Repository
{
    public class BannerRepository : RepositoryBase<Tbl_Banner>
    {
        public BannerRepository(TicketDbContext dbContext) : base(dbContext)
        {
        }

        public Tbl_Banner GetOrderByDescendingOrFirst()
        {
            return _dbset.AsQueryable().OrderByDescending(a => a.Order).FirstOrDefault();
        }

        public Tbl_Banner GetOrderByDescendingOrFirst(Expression<Func<Tbl_Banner, bool>> expression)
        {
            return _dbset.Where(expression).OrderByDescending(a => a.Order).FirstOrDefault();
        }

        public Tbl_Banner GetOrderByOrFirst(Expression<Func<Tbl_Banner, bool>> expression)
        {
            return _dbset.Where(expression).OrderBy(a => a.Order).FirstOrDefault();
        }
    }
}
