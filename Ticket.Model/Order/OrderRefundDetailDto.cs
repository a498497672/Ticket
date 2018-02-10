using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Order
{
    public class OrderRefundDetailDto
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public string TotalFee { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public string RefundFee { get; set; }
        /// <summary>
        /// 商户退款订单号
        /// </summary>
        public string OutRefundNo { get; set; }
    }
}
