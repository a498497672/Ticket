using System.ComponentModel.DataAnnotations;

namespace Ticket.Model.Order
{
    /// <summary>
    /// 退款
    /// </summary>
    public class OrderRefundDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Required(ErrorMessage = "订单号不能为空")]
        public string OrderNo { get; set; }
    }
}
