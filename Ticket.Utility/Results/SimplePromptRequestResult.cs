using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket.Utility.Messages;

namespace Ticket.Utility.Results
{
    /// <summary>
    /// 提示错误
    /// </summary>
    public class SimplePromptRequestResult : IHttpActionResult
    {
        public SimplePromptRequestResult(HttpRequestMessage request, ErrorMessage errorMessage)
        {
            Request = request;
            ErrorMessage = errorMessage;
        }

        public HttpRequestMessage Request { get; }
        public ErrorMessage ErrorMessage { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, ErrorMessage);
            return Task.FromResult(response);
        }
    }
}
