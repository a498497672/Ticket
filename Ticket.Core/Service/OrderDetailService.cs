using System;
using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Enum;
using Ticket.Utility.Exceptions;

namespace Ticket.Core.Service
{
    public class OrderDetailService
    {
        private readonly OrderDetailRepository _orderDetailRepository;
        private readonly TicketService _ticketService;

        public OrderDetailService(
            OrderDetailRepository orderDetailRepository,
            TicketService ticketService)
        {
            _orderDetailRepository = orderDetailRepository;
            _ticketService = ticketService;
        }

        /// <summary>
        /// 获取订单详情 门票
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public Tbl_OrderDetail Get(string orderNo)
        {
            return _orderDetailRepository.FirstOrDefault(a => a.OrderNo == orderNo);
        }


        /// <summary>
        /// 添加订单详情 扫一扫
        /// </summary>
        /// <param name="order"></param>
        /// <param name="tbl_Order"></param>
        /// <returns></returns>
        public Tbl_OrderDetail Add(Tbl_Order tbl_Order, Tbl_Ticket tbl_Ticket)
        {
            if (tbl_Ticket == null)
            {
                throw new SimplePromptException("门票未找到");
            }
            Tbl_OrderDetail tbl_OrderDetail = new Tbl_OrderDetail
            {
                Number = Guid.NewGuid(),
                OrderNo = tbl_Order.OrderNo,
                OrderType = tbl_Order.OrderType,
                SellerId = 0,
                SellerType = 1,
                OtaOrderDetailId = 0,
                OrderSource = 1,
                TicketSource = 1,
                TicketCategory = 1,
                UsedQuantity = 0,
                TicketId = tbl_Ticket.TicketId,
                TicketName = tbl_Ticket.TicketName,
                Price = tbl_Ticket.SalePrice,
                Quantity = tbl_Order.BookCount,
                BarCode = "",
                Stub = "",
                CertificateNO = "",
                OrderStatus = (int)OrderDetailStatusType.NoPay,
                CreateTime = DateTime.Now,
                ValidityDateStart = tbl_Order.ValidityDateStart,
                ValidityDateEnd = tbl_Order.ValidityDateEnd,
                QRcodeUrl = "",
                QRcode = "",
                Mobile = tbl_Order.Mobile,
                IDCard = "",
                Linkman = tbl_Order.Linkman,
                BuyUserId = tbl_Order.BuyUserId,
                CanModify = true,
                CanRefund = true,
            };
            _orderDetailRepository.Add(tbl_OrderDetail);
            return tbl_OrderDetail;
        }

        /// <summary>
        /// 添加订单详情 余额支付
        /// </summary>
        /// <param name="order"></param>
        /// <param name="tbl_Order"></param>
        /// <returns></returns>
        public Tbl_OrderDetail AddForBalancePay(Tbl_Order tbl_Order, Tbl_Ticket tbl_Ticket)
        {
            if (tbl_Ticket == null)
            {
                throw new SimplePromptException("门票未找到");
            }
            Tbl_OrderDetail tbl_OrderDetail = new Tbl_OrderDetail
            {
                Number = Guid.NewGuid(),
                OrderNo = tbl_Order.OrderNo,
                OrderType = tbl_Order.OrderType,
                SellerId = 0,
                SellerType = 1,
                OtaOrderDetailId = 0,
                OrderSource = 1,
                TicketSource = 1,
                TicketCategory = 1,
                UsedQuantity = 0,
                TicketId = tbl_Ticket.TicketId,
                TicketName = tbl_Ticket.TicketName,
                Price = tbl_Ticket.SalePrice,
                Quantity = tbl_Order.BookCount,
                BarCode = "",
                Stub = "",
                CertificateNO = "",
                OrderStatus = (int)OrderDetailStatusType.Success,

                CreateTime = DateTime.Now,
                ValidityDateStart = tbl_Order.ValidityDateStart,
                ValidityDateEnd = tbl_Order.ValidityDateEnd,
                QRcodeUrl = "",
                QRcode = "",
                Mobile = tbl_Order.Mobile,
                IDCard = "",
                Linkman = tbl_Order.Linkman,
                BuyUserId = tbl_Order.BuyUserId,
                CanModify = true,
                CanRefund = true,
            };
            _orderDetailRepository.Add(tbl_OrderDetail);
            return tbl_OrderDetail;
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="tbl_Order"></param>
        /// <returns></returns>
        public Tbl_OrderDetail AddForRecharge(Tbl_Order tbl_Order)
        {
            Tbl_OrderDetail tbl_OrderDetail = new Tbl_OrderDetail
            {
                Number = Guid.NewGuid(),
                OrderNo = tbl_Order.OrderNo,
                OrderType = tbl_Order.OrderType,
                SellerId = 0,
                SellerType = 1,
                OtaOrderDetailId = 0,
                OrderSource = 1,
                TicketSource = 1,
                TicketCategory = 1,
                UsedQuantity = 0,
                TicketId = 0,
                TicketName = tbl_Order.TicketName,
                Price = tbl_Order.TotalAmount,
                Quantity = tbl_Order.BookCount,
                BarCode = "",
                Stub = "",
                CertificateNO = "",
                OrderStatus = (int)OrderDetailStatusType.NoPay,
                CreateTime = DateTime.Now,
                ValidityDateStart = tbl_Order.ValidityDateStart,
                ValidityDateEnd = tbl_Order.ValidityDateEnd,
                QRcodeUrl = "",
                QRcode = "",
                Mobile = tbl_Order.Mobile,
                IDCard = "",
                Linkman = tbl_Order.Linkman,
                BuyUserId = tbl_Order.BuyUserId,
                CanModify = true,
                CanRefund = true,
            };
            _orderDetailRepository.Add(tbl_OrderDetail);
            return tbl_OrderDetail;
        }

        /// <summary>
        /// 修改订单详情
        /// </summary>
        /// <param name="orderNo">订单号</param>
        public void UpdateForPay(string orderNo)
        {
            var Tbl_OrderDetails = _orderDetailRepository.GetList(a => a.OrderNo == orderNo);
            if (Tbl_OrderDetails.Count > 0)
            {
                foreach (var row in Tbl_OrderDetails)
                {
                    row.OrderStatus = (int)OrderDetailStatusType.Success;
                    _orderDetailRepository.Update(row);
                }
            }

        }

        /// <summary>
        /// 检查是否可以退款
        /// </summary>
        /// <param name="orderNo"></param>
        public Tbl_OrderDetail CheckIsRefund(string orderNo)
        {
            var tbl_OrderDetail = _orderDetailRepository.FirstOrDefault(a => a.OrderNo == orderNo);
            if (tbl_OrderDetail == null)
            {
                throw new SimplePromptException("未找到该订单");
            }
            if (tbl_OrderDetail.OrderStatus == (int)OrderDetailStatusType.Refund)
            {
                throw new SimplePromptException("申请退款失败，订单已退款");
            }
            if (tbl_OrderDetail.OrderStatus == (int)OrderDetailStatusType.Canncel)
            {
                throw new SimplePromptException("申请退款失败，订单已取消");
            }
            if (tbl_OrderDetail.OrderStatus == (int)OrderDetailStatusType.Consume)
            {
                throw new SimplePromptException("申请退款失败，订单已消费");
            }
            if (tbl_OrderDetail.CanRefund == false)
            {
                throw new SimplePromptException("申请退款失败，您选购的产品不支持退款");
            }
            if (tbl_OrderDetail.CanRefund && tbl_OrderDetail.CanRefundTime != null && tbl_OrderDetail.CanRefundTime < DateTime.Now)
            {
                throw new SimplePromptException("申请退款失败，订单未消费但已过最后退款时间");
            }
            return tbl_OrderDetail;
        }

        /// <summary>
        /// 修改订单状态--退款
        /// </summary>
        /// <param name="tbl_Order"></param>
        public void UpdateForRefund(Tbl_OrderDetail  tbl_OrderDetail)
        {
            tbl_OrderDetail.OrderStatus = (int)OrderDetailStatusType.Refund;
            tbl_OrderDetail.CancelTime = DateTime.Now;
            _orderDetailRepository.Update(tbl_OrderDetail);
        }
    }
}
