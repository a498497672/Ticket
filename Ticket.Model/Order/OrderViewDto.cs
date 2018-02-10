using Ticket.Model.Enum;
using Ticket.Utility.Helper;

namespace Ticket.Model.Order
{
    public class OrderViewDto
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string TicketName { get; set; }
        /// <summary>
        /// 产品购买数量
        /// </summary>
        public int BookCount { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 入园日期
        /// </summary>
        public string ValidityDate { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 状态名称
        /// </summary>
        public string OrderStatusName
        {
            get
            {
                return ((OrderStatusType)OrderStatus).GetDescriptionName();
            }
        }
        /// <summary>
        /// 产品图片
        /// </summary>
        public string Image { get; set; }
    }
}
