using System;
using System.Collections.Generic;
using Ticket.Core.Repository;
using Ticket.EntityFramework;
using Ticket.EntityFramework.Entities;
using Ticket.Infrastructure.WxPay.Response;
using Ticket.Model.Enum;
using Ticket.Model.Order;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Helper;

namespace Ticket.Core.Service
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly TicketService _ticketService;
        private readonly WeiXinUserService _weiXinUserService;
        private readonly OrderDetailService _orderDetailService;
        private readonly IntegralDetailsService _integralDetailsService;

        public OrderService(
            OrderRepository orderRepository,
            TicketService ticketService,
            WeiXinUserService weiXinUserService,
            OrderDetailService orderDetailService,
            IntegralDetailsService integralDetailsService)
        {
            _orderRepository = orderRepository;
            _ticketService = ticketService;
            _weiXinUserService = weiXinUserService;
            _orderDetailService = orderDetailService;
            _integralDetailsService = integralDetailsService;
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public Tbl_Order Get(string orderNo)
        {
            return _orderRepository.FirstOrDefault(a => a.OrderNo == orderNo);
        }

        /// <summary>
        /// 获取订单列表--门票
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<Tbl_Order> GetListForTicket(string openId)
        {
            return _orderRepository.GetList(a => a.OpenId == openId && a.OrderType == (int)OrderType.Ticket);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        public Tbl_Order Create(OrderCreateDto orderCreateDto)
        {
            _weiXinUserService.BindWeChatAcount(orderCreateDto.OpenId, orderCreateDto.Mobile, orderCreateDto.Verifycode);
            var tbl_Ticket = _ticketService.Get(orderCreateDto.TravelTime, orderCreateDto.TicketId);
            var tbl_Order = AddOrder(orderCreateDto, tbl_Ticket);
            _orderDetailService.Add(tbl_Order, tbl_Ticket);
            return tbl_Order;
        }

        /// <summary>
        /// 余额支付
        /// </summary>
        /// <param name="orderCreateDto"></param>
        public Tbl_Order BalancePay(OrderCreateDto orderCreateDto)
        {
            _weiXinUserService.BindWeChatAcount(orderCreateDto.OpenId, orderCreateDto.Mobile, orderCreateDto.Verifycode);
            var tbl_Ticket = _ticketService.Get(orderCreateDto.TravelTime, orderCreateDto.TicketId);
            var tbl_Order = AddOrderForBalancePay(orderCreateDto, tbl_Ticket);
            _orderDetailService.AddForBalancePay(tbl_Order, tbl_Ticket);
            _weiXinUserService.UpdateForBalancePay(tbl_Order);
            _integralDetailsService.AddForBalanceConsumption(tbl_Order);
            return tbl_Order;
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="orderCreateDto"></param>
        public Tbl_Order Recharge(OrderRechargeDto orderRechargeDto)
        {
            var tbl_Order = AddOrderForRecharge(orderRechargeDto);
            _orderDetailService.AddForRecharge(tbl_Order);
            return tbl_Order;
        }


        /// <summary>
        /// 支付结果回调
        /// </summary>
        /// <param name="payNotifyResponse"></param>
        public void PayNotify(PayNotifyResponse payNotifyResponse)
        {
            var tbl_Order = Get(payNotifyResponse.OutTradeNo);
            if (tbl_Order == null || tbl_Order.OrderStatus != (int)OrderStatusType.NoPay)
            {
                return;
            }
            if (tbl_Order.OrderType == (int)OrderType.Recharge)
            {
                UpdateOrder(tbl_Order, payNotifyResponse.TransactionId);
                _orderDetailService.UpdateForPay(payNotifyResponse.OutTradeNo);
                _weiXinUserService.UpdateForBalanceRecharge(tbl_Order);
                _integralDetailsService.AddForRecharge(tbl_Order);
            }
            else
            {
                UpdateOrder(tbl_Order, payNotifyResponse.TransactionId);
                _orderDetailService.UpdateForPay(payNotifyResponse.OutTradeNo);
                _weiXinUserService.UpdateForSaleMoney(tbl_Order);
                _integralDetailsService.AddForWechatConsumption(tbl_Order);
            }
        }


        /// <summary>
        /// 检查是否可以退款
        /// </summary>
        /// <param name="orderNo"></param>
        public Tbl_Order CheckIsRefund(string orderNo)
        {
            var tbl_Order = _orderRepository.FirstOrDefault(a => a.OrderNo == orderNo);
            if (tbl_Order == null)
            {
                throw new SimplePromptException("未找到该订单");
            }
            if (tbl_Order.OrderStatus == (int)OrderStatusType.Canncel)
            {
                throw new SimplePromptException("申请退款失败，订单已取消");
            }
            return tbl_Order;
        }

        /// <summary>
        /// 修改订单状态--退款
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void UpdateForRefund(Tbl_Order tbl_Order)
        {
            tbl_Order.OrderStatus = (int)OrderStatusType.Canncel;
            tbl_Order.CancelTime = DateTime.Now;
            _orderRepository.Update(tbl_Order);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="transaction_id"></param>
        /// <param name="tbl_Order"></param>
        private void UpdateOrder(Tbl_Order tbl_Order, string transaction_id)
        {
            tbl_Order.OrderStatus = (int)OrderStatusType.Success;
            tbl_Order.PayTime = DateTime.Now;//付款时间
            tbl_Order.PayTradeNo = transaction_id;
            _orderRepository.Update(tbl_Order);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        private Tbl_Order AddOrder(OrderCreateDto orderCreateDto, Tbl_Ticket tbl_Ticket)
        {
            if (tbl_Ticket == null)
            {
                throw new SimplePromptException("门票未找到");
            }
            //创建订单号
            string orderNo = OrderHelper.GenerateOrderNo();
            //订单
            Tbl_Order tbl_Order = new Tbl_Order
            {
                OrderNo = orderNo,
                OpenId = orderCreateDto.OpenId,
                TicketSource = 1,
                PayType = (int)PayType.Wechat,
                PayAccount = "",
                PayTradeNo = "",
                SellerId = 0,
                Price = 0,
                Linkman = orderCreateDto.Linkman,
                Mobile = orderCreateDto.Mobile,
                OrderStatus = (int)OrderStatusType.NoPay,
                CreateTime = DateTime.Now,
                ValidityDateStart = orderCreateDto.TravelTime,
                ValidityDateEnd = orderCreateDto.TravelTime,
                BookCount = orderCreateDto.BookCount,
                UsedQuantity = 0,
                Remark = "",
                IDCard = "",
                CreateUserId = 0,
                OrderType = (int)OrderType.Ticket,
            };
            var ticketNames = tbl_Ticket.TicketName;
            if (ticketNames.Length > 50)
            {
                ticketNames = ticketNames.Substring(0, 50);
            }
            tbl_Order.TicketName = ticketNames;
            tbl_Order.TotalAmount = tbl_Ticket.SalePrice * tbl_Order.BookCount;
            _orderRepository.Add(tbl_Order);
            return tbl_Order;
        }

        /// <summary>
        /// 创建订单余额支付
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        private Tbl_Order AddOrderForBalancePay(OrderCreateDto orderCreateDto, Tbl_Ticket tbl_Ticket)
        {
            if (tbl_Ticket == null)
            {
                throw new SimplePromptException("门票未找到");
            }
            //创建订单号
            string orderNo = OrderHelper.GenerateOrderNo();
            //订单
            Tbl_Order tbl_Order = new Tbl_Order
            {
                OrderNo = orderNo,
                OpenId = orderCreateDto.OpenId,
                TicketSource = 1,
                PayType = (int)PayType.Balance,
                PayAccount = "",
                PayTradeNo = "",
                SellerId = 0,
                Price = 0,
                Linkman = orderCreateDto.Linkman,
                Mobile = orderCreateDto.Mobile,
                OrderStatus = (int)OrderStatusType.Success,
                PayTime = DateTime.Now,
                CreateTime = DateTime.Now,
                ValidityDateStart = orderCreateDto.TravelTime,
                ValidityDateEnd = orderCreateDto.TravelTime,
                BookCount = orderCreateDto.BookCount,
                UsedQuantity = 0,
                Remark = "",
                IDCard = "",
                CreateUserId = 0,
                OrderType = (int)OrderType.Ticket,
            };
            var ticketNames = tbl_Ticket.TicketName;
            if (ticketNames.Length > 50)
            {
                ticketNames = ticketNames.Substring(0, 50);
            }
            tbl_Order.TicketName = ticketNames;
            tbl_Order.TotalAmount = tbl_Ticket.SalePrice * tbl_Order.BookCount;
            _orderRepository.Add(tbl_Order);
            return tbl_Order;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        private Tbl_Order AddOrderForRecharge(OrderRechargeDto orderRechargeDto)
        {
            //创建订单号
            string orderNo = OrderHelper.GenerateOrderNo();
            //订单
            Tbl_Order tbl_Order = new Tbl_Order
            {
                OrderNo = orderNo,
                OpenId = orderRechargeDto.OpenId,
                TicketName = "充值",
                TotalAmount = orderRechargeDto.Amount,
                PayType = (int)PayType.Wechat,
                OrderStatus = (int)OrderStatusType.NoPay,
                ValidityDateStart = DateTime.Now,
                ValidityDateEnd = DateTime.Now,
                OrderType = (int)OrderType.Recharge,
                CreateTime = DateTime.Now,
                BookCount = 1,
                Linkman = "",
                Mobile = "",
                TicketSource = 1,
                PayAccount = "",
                PayTradeNo = "",
                SellerId = 0,
                Price = 0,
                UsedQuantity = 0,
                Remark = "",
                IDCard = "",
                CreateUserId = 0,
            };
            _orderRepository.Add(tbl_Order);
            return tbl_Order;
        }
    }
}
