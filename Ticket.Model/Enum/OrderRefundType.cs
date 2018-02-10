using System.ComponentModel;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 退款状态
    /// </summary>
    public enum OrderRefundType
    {
        /// <summary>
        /// 申请中
        /// </summary>
        [Description("申请中")]
        Wait = 0,

        /// <summary>
        /// 退票成功
        /// </summary>
        [Description("退票成功")]
        Success = 1,

        /// <summary>
        /// 退票失败
        /// </summary>
        [Description("退票失败")]
        Fail = 2,

        /// <summary>
        /// 拒绝退票
        /// </summary>
        [Description("拒绝退票")]
        Refuse = 3,
    }
}
