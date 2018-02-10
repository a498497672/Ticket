namespace Ticket.Model.Order
{
    public class OrderCreateViewDto
    {
        /// <summary>
        /// 微信浏览器调起jsapi支付所需的参数
        /// </summary>
        public string JsApiParameters { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
    }
}
