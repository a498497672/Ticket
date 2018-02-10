using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;

namespace Ticket.Application.ValidateCode
{
    public class ValidateCodeFacadeService
    {
        private readonly ValidateCodeService _validateCodeService;
        public ValidateCodeFacadeService(ValidateCodeService validateCodeService)
        {
            _validateCodeService = validateCodeService;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        public void SendCodeForValidateMobile(string mobile)
        {
            _validateCodeService.SendCodeForValidateMobile(mobile);
        }
    }
}
