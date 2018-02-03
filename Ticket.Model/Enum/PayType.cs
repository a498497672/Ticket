using System.ComponentModel;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType
    {
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        Alipay = 1,

        /// <summary>
        /// 微信
        /// </summary>
        [Description("微信")]
        Wechat = 2,

        /// <summary>
        /// 现金
        /// </summary>
        [Description("现金")]
        ReadyMoney = 3,
        /// <summary>
        /// 银行转账
        /// </summary>
        [Description("银行转账")]
        BankTransfer = 4,
        /// <summary>
        /// 余额
        /// </summary>
        [Description("余额")]
        Balance = 5,
    }

    /// <summary>
    /// 微信公众号支付方式
    /// </summary>
    public enum WechatPublicPayTypeEnum
    {
        /// <summary>
        /// 微信
        /// </summary>
        [Description("微信")]
        Wechat = 0,
        /// <summary>
        /// 余额
        /// </summary>
        [Description("余额")]
        Balance = 1,
    }
}
