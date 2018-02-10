using System.Collections.Generic;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;
using Ticket.Infrastructure.WxPay.Request;
using Ticket.Model.Enum;
using Ticket.Model.Order;
using Ticket.Utility.UnitOfWorks;

namespace Ticket.Application.Order
{
    public class OrderFacadeService
    {
        private readonly OrderService _orderService;
        private readonly WxPayService _wxPayService;
        private readonly WeiXinUserService _weiXinUserService;

        public OrderFacadeService(
            OrderService orderService,
            WxPayService wxPayService,
            WeiXinUserService weiXinUserService)
        {
            _orderService = orderService;
            _wxPayService = wxPayService;
            _weiXinUserService = weiXinUserService;
        }

        public Tbl_Order Get(string orderNo)
        {
            return _orderService.Get(orderNo);
        }

        /// <summary>
        /// 获取订单列表--门票
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<Tbl_Order> GetListForTicket(string openId)
        {
            return _orderService.GetListForTicket(openId);
        }

        /// <summary>
        /// 支付结果回调
        /// </summary>
        public void PayNotify()
        {
            var payNotify = _wxPayService.PayNotify();
            using (var unitOfWork = new UnitOfWork())
            {
                _orderService.PayNotify(payNotify);
                unitOfWork.Commit();
            }
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        public OrderCreateViewDto Create(OrderCreateDto orderCreateDto)
        {
            var tbl_Order = new Tbl_Order();
            using (var unitOfWork = new UnitOfWork())
            {
                tbl_Order = _orderService.Create(orderCreateDto);
                unitOfWork.Commit();
            }
            var jsApiParameters = _wxPayService.PayOrderForTicket(tbl_Order);
            return new OrderCreateViewDto
            {
                OrderNo = tbl_Order.OrderNo,
                JsApiParameters = jsApiParameters
            };
        }

        /// <summary>
        /// 余额支付 返回订单号
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        public string BalancePay(OrderCreateDto orderCreateDto)
        {
            var tbl_Order = new Tbl_Order();
            //余额支付
            using (var unitOfWork = new UnitOfWork())
            {
                tbl_Order = _orderService.BalancePay(orderCreateDto);
                unitOfWork.Commit();
            }
            return tbl_Order.OrderNo;
        }

        /// <summary>
        /// 再次支付
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        public OrderCreateViewDto PayAgain(Tbl_Order tbl_Order)
        {
            var jsApiParameters = _wxPayService.PayOrderForTicket(tbl_Order);
            return new OrderCreateViewDto
            {
                OrderNo = tbl_Order.OrderNo,
                JsApiParameters = jsApiParameters
            };
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="orderCreateDto"></param>
        public OrderCreateViewDto Recharge(OrderRechargeDto orderRechargeDto)
        {
            _weiXinUserService.CheckIsExist(orderRechargeDto.OpenId);
            var tbl_Order = new Tbl_Order();
            using (var unitOfWork = new UnitOfWork())
            {
                tbl_Order = _orderService.Recharge(orderRechargeDto);
                unitOfWork.Commit();
            }
            var jsApiParameters = _wxPayService.PayOrderForTicket(tbl_Order);
            return new OrderCreateViewDto
            {
                OrderNo = tbl_Order.OrderNo,
                JsApiParameters = jsApiParameters
            };
        }
    }
}
