using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket.Application.ValidateCode;
using Ticket.Model.ValidateCode;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/VerifCode")]
    public class VerifCodeController : ApiController
    {
        private readonly ValidateCodeFacadeService _validateCodeFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validateCodeFacadeService"></param>
        public VerifCodeController(ValidateCodeFacadeService validateCodeFacadeService)
        {
            _validateCodeFacadeService = validateCodeFacadeService;
        }

        /// <summary>
        /// 发送验证短信
        /// </summary>
        /// <param name="validateCodeDto">验证模型.</param>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("Send")]
        public IHttpActionResult Post(ValidateCodeDto validateCodeDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            _validateCodeFacadeService.SendCodeForValidateMobile(validateCodeDto.Mobile);
            var result = new TResult();
            return Ok(result.SuccessResult());
        }
    }
}
