using System.ComponentModel.DataAnnotations;
using Ticket.Utility.Validation;

namespace Ticket.Model.User
{
    /// <summary>
    /// 加入会员
    /// </summary>
    public class UserAddMembershipDto
    {
        [Required(ErrorMessage = "OpenId不能为空")]
        public string OpenId { get; set; }
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
        [Required(ErrorMessage = "身份证不能为空")]
        [IdCard(ErrorMessage = "身份证号不规范，请保证身份证为18位且填写正确")]
        public string CardNo { get; set; }
    }
}
