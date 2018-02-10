using System;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Model.Order;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Helper;

namespace Ticket.Core.Service
{
    public class OrderRefundDetailService
    {
        private readonly OrderRefundDetailRepository _orderRefundDetailRepository;
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderService _orderService;

        public OrderRefundDetailService(
            OrderRefundDetailRepository orderRefundDetailRepository,
            OrderDetailService orderDetailService,
            OrderService orderService)
        {
            _orderRefundDetailRepository = orderRefundDetailRepository;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public OrderRefundDetailDto Refund(string orderNo)
        {
            var tbl_Order = _orderService.CheckIsRefund(orderNo);
            var tbl_OrderDetail = _orderDetailService.CheckIsRefund(orderNo);
            var tbl_OrderRefundDetail = AddForTicket(tbl_OrderDetail);
            _orderService.UpdateForRefund(tbl_Order);
            _orderDetailService.UpdateForRefund(tbl_OrderDetail);
            return new OrderRefundDetailDto
            {
                OutRefundNo = tbl_OrderRefundDetail.OrderRefundNo,
                TransactionId = tbl_Order.PayTradeNo,
                TotalFee = (tbl_Order.TotalAmount * 100).ToString(),
                RefundFee = (tbl_Order.TotalAmount * 100).ToString()
            };
        }

        /// <summary>
        /// 添加退款记录
        /// </summary>
        /// <param name="tbl_OrderDetail"></param>
        public Tbl_OrderRefundDetail AddForTicket(Tbl_OrderDetail tbl_OrderDetail)
        {
            Tbl_OrderRefundDetail tbl_OrderRefundDetail = new Tbl_OrderRefundDetail
            {
                OrderRefundNo = OrderHelper.GenerateOrderNo(),
                OrderDetailId = tbl_OrderDetail.OrderDetailId,
                OrderNo = tbl_OrderDetail.OrderNo,
                Quantity = tbl_OrderDetail.Quantity,
                Price = tbl_OrderDetail.Price,
                RefundStatus = (int)OrderRefundType.Success,
                RefundQuantity = tbl_OrderDetail.Quantity,
                RefundFee = 0,
                RefundTotalAmount = (tbl_OrderDetail.Price * tbl_OrderDetail.Quantity),
                RefundSummary = "",
                OrderTime = tbl_OrderDetail.CreateTime,

                CreateTime = DateTime.Now,
            };
            _orderRefundDetailRepository.Add(tbl_OrderRefundDetail);
            return tbl_OrderRefundDetail;
        }
    }
}
