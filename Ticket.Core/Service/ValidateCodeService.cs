using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Helper;

namespace Ticket.Core.Service
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    public class ValidateCodeService
    {
        private readonly ValidateCodeRepository _validateCodeRepository;
        private readonly SmsService _smsService;
        public ValidateCodeService(ValidateCodeRepository validateCodeRepository,
            SmsService smsService)
        {
            _validateCodeRepository = validateCodeRepository;
            _smsService = smsService;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        public void SendCodeForValidateMobile(string mobile)
        {
            string code = SendCode(mobile, ValidateCodeType.Mobile);
            _smsService.SendValidateCode(mobile, code);
        }

        /// <summary>
        /// 验证码10分钟内有效
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public void IsValideCode(string mobile, string validateCode)
        {
            var model = _validateCodeRepository.FirstOrDefault(a => a.Mobile == mobile && a.DataStatus == false, a => a.CreateTime, false);
            if (model == null)
            {
                throw new SimplePromptException("验证码已失效");
            }
            if (validateCode != model.ValidateCode)
            {
                throw new SimplePromptException("验证码已失效");
            }
            TimeSpan ts = DateTime.Now - model.CreateTime;
            if (ts.TotalMinutes > 10)
            {
                throw new SimplePromptException("验证码已过期");
            }
            model.DataStatus = true;
            _validateCodeRepository.Update(model);
        }





        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        private string SendCode(string mobile, ValidateCodeType type)
        {
            var code = StringHelper.RandNum(6);
            _validateCodeRepository.Add(new Tbl_ValidateCode
            {
                ClientIp = ClientIpHelper.GetInnerIp(),
                ValidateCode = code,
                Mobile = mobile,
                TypeId = (int)type,
                DataStatus = false,
                CreateTime = DateTime.Now
            });
            return code;
        }
    }
}
