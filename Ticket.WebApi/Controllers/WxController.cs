using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ticket.Application.WeiXin;
using Ticket.Infrastructure.WxPay.Response;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/wx")]
    public class WxController : ApiController
    {
        private readonly WxPayFacadeService _wxPayFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wxPayFacadeService"></param>
        public WxController(WxPayFacadeService wxPayFacadeService)
        {
            _wxPayFacadeService = wxPayFacadeService;
        }

        /// <summary>
        /// 微信授权
        /// </summary>
        /// <response code="200">成功.</response>
        /// <param name="code">微信用户授权Code</param>
        /// <returns></returns>
        [Route("wxOAuth")]
        [ResponseType(typeof(TResult<string>))]
        public IHttpActionResult GetWxOAuth(string code)
        {
            var openId = _wxPayFacadeService.GetOpenId(code);
            var result = new TResult<string>();
            return Ok(result.SuccessResult(openId));
        }

        /// <summary>
        /// 获取JS-SDK配置
        /// </summary>
        /// <param name="url">当前页面的url去掉后面的#</param>
        /// <returns></returns>
        [Route("GetWxConfig")]
        [ResponseType(typeof(TResult<JsSDKResponse>))]
        public IHttpActionResult GetWxConfig(string url)
        {
            var data = _wxPayFacadeService.GetJsSDKTicket(url);
            var result = new TResult<JsSDKResponse>();
            return Ok(result.SuccessResult(data));
        }
    }
}
