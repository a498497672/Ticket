using System.ComponentModel.DataAnnotations;

namespace Ticket.Model.Order
{
    /// <summary>
    /// 再次支付
    /// </summary>
    public class OrderPayAgainDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Required(ErrorMessage = "订单号不能为空")]
        public string OrderNo { get; set; }
    }
}
