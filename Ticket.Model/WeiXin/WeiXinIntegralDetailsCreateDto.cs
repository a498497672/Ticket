using Ticket.Model.Enum;

namespace Ticket.Model.WeiXin
{
    public class WeiXinIntegralDetailsCreateDto
    {
        public string Name { get; set; }
        public string OpenId { get; set; }
        public decimal Amount { get; set; }
        public IntegralType Type { get; set; }
        public WechatPublicPayTypeEnum PayType { get; set; }
    }
}
