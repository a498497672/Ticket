using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Scenic
{
    public class TicketViewDto
    {
        /// <summary>
        /// 门票Id
        /// </summary>
        public int TicketId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string TicketName { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal? MarkPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalesPrice { get; set; }
        /// <summary>
        /// 日库存量(0:表示不限制)
        /// </summary>
        public int StockCount { get; set; }
        /// <summary>
        /// 是否支持退款
        /// </summary>
        public bool CanRefund { get; set; }
        /// <summary>
        /// 订购说明
        /// </summary>
        public string TicketNotice { get; set; }
        /// <summary>
        /// 入园说明
        /// </summary>
        public string EnterNotice { get; set; }
        /// <summary>
        /// 退订说明
        /// </summary>
        public string RefundNotice { get; set; }
        /// <summary>
        /// 最小起购数
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// 最大订购数
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// 景区图片
        /// </summary>
        public string MainImg { get; set; }
    }
}
