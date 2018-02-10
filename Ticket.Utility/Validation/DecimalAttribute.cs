using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ticket.Utility.Validation
{
    /// <summary>
    /// 验证金额格式(保留2位小数)
    /// </summary>
    public class DecimalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((string)value != string.Empty)
            {
                var isValid = Regex.IsMatch(value.ToString(), @"^\d{1,10}(\.\d{1,2})?$");
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
