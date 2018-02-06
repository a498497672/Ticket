using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Infrastructure.WxPay;
using Ticket.Infrastructure.WxPay.Response;
using Ticket.Utility.Exceptions;

namespace Ticket.Core.Service
{
    public class WxPayService
    {
        private readonly WeiXinUserService _weiXinUserService;
        private readonly PaymentGateway _paymentGateway;
        public WxPayService(WeiXinUserService weiXinUserService, PaymentGateway paymentGateway)
        {
            _weiXinUserService = weiXinUserService;
            _paymentGateway = paymentGateway;
        }

        public string GetAppId()
        {
            return _paymentGateway.GetAppId();
        }

        /// <summary>
        /// 获取微信用户唯一标识
        /// </summary>
        /// <param name="code">微信用户授权Code</param>
        /// <returns></returns>
        public string GetOpenId(string code)
        {
            var token = _paymentGateway.GetAccessToken(code);
            if (token == null)
            {
                throw new SimplePromptException("获取授权access_token失败");
            }
            var weiXinUser = _weiXinUserService.GetByOpenId(token.Openid);
            if (weiXinUser == null)
            {
                AddWeiXinUser(token);
            }
            return token.Openid;
        }

        /// <summary>
        /// 分享到朋友圈参数自定义
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JsSDKResponse GetJsSDKTicket(string url)
        {
            return _paymentGateway.GetJsSDKTicket(url);
        }


        /// <summary>
        /// 添加微信用户信息
        /// </summary>
        /// <param name="token"></param>
        private void AddWeiXinUser(Infrastructure.WxPay.Response.AauthResponse token)
        {
            var userInfo = _paymentGateway.GetUserInfo(token.AccessToken, token.Openid);
            if (userInfo == null)
            {
                throw new SimplePromptException("获取用户信息失败");
            }
            _weiXinUserService.Add(new Tbl_WeiXin_User
            {
                Sex = Convert.ToInt32(userInfo.Sex),
                City = userInfo.City,
                Province = userInfo.Province,
                Country = userInfo.Country,
                HeaderImage = userInfo.HeadImgUrl,
                NickName = userInfo.NickName,
                OpenId = userInfo.OpenId,
            });
        }
    }
}
