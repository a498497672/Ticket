using System.Collections.Generic;

namespace Ticket.Utility.Searchs
{
    public class PagedResult<TItem>
    {
        public PagedResult() { }

        public PagedResult(List<TItem> items, int count)
        {
            Data = items;
            TotalCount = count;
        }

        /// <summary>
        /// 数据
        /// </summary>
        public List<TItem> Data { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                var totalPages = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                {
                    totalPages++;
                }
                return totalPages;
            }
        }
    }
}
