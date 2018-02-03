using System.ComponentModel;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 积分类型
    /// </summary>
    public enum IntegralType
    {
        /// <summary>
        /// 每日登录
        /// </summary>
        [Description("每日登录")]
        EverydayLogin = 1,
        /// <summary>
        /// 充值
        /// </summary>
        [Description("充值")]
        Recharge = 2,
        /// <summary>
        /// 消费
        /// </summary>
        [Description("消费")]
        Consumption = 3
    }
}
