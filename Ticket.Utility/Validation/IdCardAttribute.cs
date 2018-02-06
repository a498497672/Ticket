using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ticket.Utility.Helper;

namespace Ticket.Utility.Validation
{
    public class IdCardAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((string)value != string.Empty)
            {
                var isValid = IdCardHelper.CheckIDCard(value.ToString());
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
