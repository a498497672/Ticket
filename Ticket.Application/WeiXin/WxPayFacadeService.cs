using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;
using Ticket.Infrastructure.WxPay.Response;

namespace Ticket.Application.WeiXin
{
    public class WxPayFacadeService
    {
        private readonly WxPayService _wxPayService;
        public WxPayFacadeService(WxPayService wxPayService)
        {
            _wxPayService = wxPayService;
        }

        public string GetAppId()
        {
            return _wxPayService.GetAppId();
        }

        /// <summary>
        /// 获取微信用户唯一标识
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetOpenId(string code)
        {
            return _wxPayService.GetOpenId(code);
        }

        /// <summary>
        /// 分享到朋友圈参数自定义
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JsSDKResponse GetJsSDKTicket(string url)
        {
            return _wxPayService.GetJsSDKTicket(url);
        }
    }
}
