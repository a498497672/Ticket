using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Utility.Exceptions
{
    /// <summary>
    /// 提示异常
    /// </summary>
    public class SimplePromptException : Exception
    {
        public SimplePromptException()
        {
        }

        public SimplePromptException(string message) : base(message)
        {
        }

        public SimplePromptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SimplePromptException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
