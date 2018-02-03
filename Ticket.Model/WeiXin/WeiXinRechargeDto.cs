namespace Ticket.Model.WeiXin
{
    /// <summary>
    /// 微信充值
    /// </summary>
    public class WeiXinRechargeDto
    {
        /// <summary>
        /// 微信用户唯一标识id
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 景区id
        /// </summary>
        public int ScenicId { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
