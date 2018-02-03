using System.Collections.Generic;
using System.Linq;
using Ticket.Utility.Searchs;

namespace Ticket.Utility.Helper
{
    public class PaginationHelper
    {
        public static PagedResult<T> FindPagedList<T>( int pageIndex, int pageSize, IQueryable<T> source)
        {
            PagedResult<T> result = new PagedResult<T>();
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 15 : pageSize;
            int total = source.Count();
            result.TotalCount = total;
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            int skipCount = 0;
            if (pageIndex > 1)
            {
                skipCount = pageSize * pageIndex - pageSize;
            }
            result.Data = source.Skip(skipCount).Take(pageSize).ToList();
            return result;
        }

        public static PagedResult<T> FindPagedList<T>(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return FindPagedList(source.AsQueryable(), pageIndex, pageSize);
        }
    }
}
