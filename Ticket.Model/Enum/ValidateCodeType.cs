using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Model.Enum
{
    /// <summary>
    /// 短信验证码
    /// </summary>
    public enum ValidateCodeType
    {
        /// <summary>
        ///  验证手机号
        /// </summary>
        [Description("验证手机号")]
        Mobile = 1,
        /// <summary>
        /// 重置密码
        /// </summary>
        [Description("重置密码")]
        ResetPassWord = 2,
    }
}
