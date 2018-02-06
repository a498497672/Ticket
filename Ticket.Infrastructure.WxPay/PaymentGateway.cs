﻿using System.Web;
using Ticket.Infrastructure.WxPay.business;
using Ticket.Infrastructure.WxPay.jsSDK;
using Ticket.Infrastructure.WxPay.Response;

namespace Ticket.Infrastructure.WxPay
{
    /// <summary>
    /// 微信支付
    /// </summary>
    public class PaymentGateway
    {
        private readonly UserInfoQuery _userInfoQuery;
        public PaymentGateway()
        {
            _userInfoQuery = new UserInfoQuery();
        }

        public string GetAppId()
        {
            return WxPayConfig.APPID;
        }

        /// <summary>
        /// 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="total">下单金额(元)</param>
        /// <param name="openId">微信用户唯一标识</param>
        /// <returns></returns>
        public string PayOrder(string orderNo, decimal total, string openId)
        {
            var wxPayApi = new JsApiPay(HttpContext.Current);
            wxPayApi.body = "【风景网】点餐系统-点餐支付";
            wxPayApi.attach = "";
            wxPayApi.openid = openId;
            wxPayApi.out_trade_no = orderNo;
            wxPayApi.total_fee = (int)(total * 100);//元转化为分
            wxPayApi.GetUnifiedOrderResult();
            return wxPayApi.GetJsApiParameters();
        }

        /// <summary>
        /// 支付结果通知回调处理类
        /// 负责接收微信支付后台发送的支付结果并对订单有效性进行验证，将验证结果反馈给微信支付后台
        /// </summary>
        /// <returns>返回订单号</returns>
        public string PayNotify()
        {
            var notifyResult = new ResultNotify(HttpContext.Current);
            var wxPayData = notifyResult.ProcessNotifyExtend();
            Log.Info("ResultNotify", wxPayData.ToJson());
            var out_trade_no = wxPayData.GetValue("out_trade_no");
            return out_trade_no.ToString();
        }

        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public AauthResponse GetAccessToken(string code)
        {
            return _userInfoQuery.GetAccessToken(code);
        }

        /// <summary>
        /// 拉取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public UserInfoResponse GetUserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            return _userInfoQuery.GetUserInfo(accessToken, openId, lang);
        }

        /// <summary>
        /// 分享到朋友圈参数自定义
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public JsSDKResponse GetJsSDKTicket(string url)
        {
            var jssdk_ticket = JSAPI.GetJsSDKTicket(WxPayConfig.APPID, WxPayConfig.APPSECRET);
            var nonceStr = WxPayApi.GenerateNonceStr();
            var timestamp = WxPayApi.GenerateTimeStamp();
            //var domain = weChat.BackDomain;
            //url = domain + url;
            var string1 = "";
            var signature = JSAPI.GetSignature(jssdk_ticket, nonceStr, timestamp, url, out string1);
            var model = new JsSDKResponse
            {
                Debug = true,
                AppId = WxPayConfig.APPID,
                Timestamp = WxPayApi.GenerateTimeStamp(),
                NonceStr = WxPayApi.GenerateNonceStr(),
                Signature = signature,
                ShareUrl = url,
                JsapiTicket = jssdk_ticket,
                //ShareImg = domain + Url.Content("/images/noimg.jpg"),
                String1 = string1,
                JsApiList = System.Configuration.ConfigurationManager.AppSettings["jsApiList"].Split(','),
            };
            return model;
        }
    }
}
