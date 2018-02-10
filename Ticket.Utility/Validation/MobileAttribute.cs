using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Ticket.Utility.Validation
{
    /// <summary>
    /// 验证手机号码是否合法
    /// </summary>
    public class MobileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((string)value != string.Empty)
            {
                var isValid = Regex.IsMatch(value.ToString(), @"^[1]\d{10}$");
                if (!isValid)
                {
                    var formatErrorMessage = FormatErrorMessage(validationContext.DisplayName);
                    var memberNames = new List<string> { validationContext.MemberName };
                    return new ValidationResult(formatErrorMessage, memberNames);
                }
            }
            return ValidationResult.Success;
        }
    }
}
