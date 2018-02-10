using System.ComponentModel;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 奖品类型, 0 谢谢参与, 1 优惠卷
    /// </summary>
    public enum PrizeType
    {
        /// <summary>
        /// 谢谢参与
        /// </summary>
        [Description("谢谢参与")]
        ThanksParticipation = 0,

        /// <summary>
        /// 优惠卷
        /// </summary>
        [Description("优惠卷")]
        Coupon = 1,
    }
}
