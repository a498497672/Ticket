namespace Ticket.Model.WeiXin
{
    /// <summary>
    /// 
    /// </summary>
    public class IntegralConfigDto
    {
        /// <summary>
        /// 每日积分
        /// </summary>
        public double Everyday { get; set; }

        /// <summary>
        /// 充值积分
        /// </summary>
        public double Recharge { get; set; }

        /// <summary>
        /// 消费积分
        /// </summary>
        public double Consumption { get; set; }
    }
}
