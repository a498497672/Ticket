using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Infrastructure.Sms;
using Ticket.Utility.Exceptions;

namespace Ticket.Core.Service
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SmsService
    {
        /// <summary>
        /// 验证码
        /// </summary>
        private readonly string _validateCode = ConfigurationManager.AppSettings["ValidateCode"];


        private readonly SmsGateway _smsGateway;
        public SmsService(SmsGateway smsGateway)
        {
            _smsGateway = smsGateway;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="code"></param>
        public void SendValidateCode(string mobile, string code)
        {
            var content = string.Format(_validateCode, code);
            Send(mobile, content);
        }

        private void Send(string mobile, string content)
        {
            var result = _smsGateway.Send(mobile, content);
            if (!result.Success)
            {
                throw new SimplePromptException(result.Message);
            }
        }
    }
}
