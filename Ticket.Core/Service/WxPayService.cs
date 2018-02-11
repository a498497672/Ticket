using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Infrastructure.WxPay;
using Ticket.Infrastructure.WxPay.Request;
using Ticket.Infrastructure.WxPay.Response;
using Ticket.Model.Order;
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
        /// 支付结果通知回调处理类
        /// </summary>
        /// <returns></returns>
        public PayNotifyResponse PayNotify()
        {
            return _paymentGateway.PayNotify();
        }

        /// <summary>
        /// 从统一下单成功返回的数据中获取微信浏览器调起jsapi支付所需的参数
        /// 门票支付
        /// </summary>
        /// <returns></returns>
        public string PayOrderForTicket(Tbl_Order tbl_Order)
        {
            return _paymentGateway.PayOrder(new PayRequest
            {
                Body = "[兄弟连] 购买门票支付",
                OpenId = tbl_Order.OpenId,
                OutTradeNo = tbl_Order.OrderNo,
                TotalFee = tbl_Order.TotalAmount
            });
        }

        /// <summary>
        /// 订单退款--微信退款
        /// </summary>
        /// <param name="refundRequest"></param>
        /// <returns></returns>
        public void OrderRefund(OrderRefundDetailDto orderRefundDetailDto)
        {
            var refund = _paymentGateway.OrderRefund(new RefundRequest
            {
                OutRefundNo = orderRefundDetailDto.OutRefundNo,
                TransactionId = orderRefundDetailDto.TransactionId,
                RefundFee = orderRefundDetailDto.RefundFee,
                TotalFee = orderRefundDetailDto.TotalFee
            });
            if (!refund)
            {
                throw new SimplePromptException("微信退款失败，请联系商家进行退款");
            }
        }

        /// <summary>
        /// 添加微信用户信息
        /// </summary>
        /// <param name="token"></param>
        private void AddWeiXinUser(AauthResponse token)
        {
            var userInfo = _paymentGateway.GetUserInfo(token.AccessToken, token.Openid);
            if (userInfo == null)
            {
                throw new SimplePromptException("获取用户信息失败");
            }
            _weiXinUserService.Add(new Tbl_WeiXinUser
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
