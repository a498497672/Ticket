using Ticket.Infrastructure.Sms.Core;
using Ticket.Infrastructure.Sms.Response;

namespace Ticket.Infrastructure.Sms
{
    /// <summary>
    /// 短信接口
    /// </summary>
    public class SmsGateway
    {
        private readonly SmsManage _smsManage;
        public SmsGateway()
        {
            _smsManage = new SmsManage();
        }

        /// <summary>
        /// 发生短信
        /// </summary>
        /// <param name="phoneList">手机号码</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public SmsResponse Send(string phoneList, string content)
        {
            return _smsManage.Send(phoneList, content);
        }
    }
}
