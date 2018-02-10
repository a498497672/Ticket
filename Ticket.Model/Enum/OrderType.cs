using System.ComponentModel;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 订单类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 0,
        /// <summary>
        /// 充值
        /// </summary>
        [Description("充值")]
        Recharge = 1,
        /// <summary>
        /// 门票
        /// </summary>
        [Description("门票")]
        Ticket = 2,
    }
}
