using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace Ticket.Utility.Exceptions
{
    public static class ModelStateDictionaryExtension
    {
        public static string BuildErrorMessage(this ModelStateDictionary modelStates)
        {
            IList<string> errorMessages = (from modelState in modelStates.Values
                                           from error in modelState.Errors
                                           select error.ErrorMessage).ToList();
            return string.Join(" ", errorMessages);
        }
    }
}
