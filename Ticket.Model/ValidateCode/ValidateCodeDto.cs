using System.ComponentModel.DataAnnotations;
using Ticket.Utility.Validation;

namespace Ticket.Model.ValidateCode
{
    public class ValidateCodeDto
    {
        [Required(ErrorMessage = "手机号码不能为空")]
        [Mobile(ErrorMessage = "手机格式不正确")]
        public string Mobile { get; set; }
    }
}
