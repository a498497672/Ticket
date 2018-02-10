using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Order;
using Ticket.Utility.UnitOfWorks;

namespace Ticket.Application.Order
{
    public class OrderDetailFacadeService
    {
        private readonly OrderDetailService _orderDetailService;
        private readonly OrderRefundDetailService _orderRefundDetailService;
        private readonly WxPayService _wxPayService;

        public OrderDetailFacadeService(
            OrderDetailService orderDetailService,
            OrderRefundDetailService orderRefundDetailService,
            WxPayService wxPayService)
        {
            _orderDetailService = orderDetailService;
            _orderRefundDetailService = orderRefundDetailService;
            _wxPayService = wxPayService;
        }

        /// <summary>
        /// 获取订单列表--门票
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Tbl_OrderDetail Get(string orderNo)
        {
            return _orderDetailService.Get(orderNo);
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public void Refund(string orderNo)
        {
            var orderRefundDetailDto = new OrderRefundDetailDto();
            using (var unitOfWork = new UnitOfWork())
            {
                orderRefundDetailDto = _orderRefundDetailService.Refund(orderNo);
                unitOfWork.Commit();
            }
            _wxPayService.OrderRefund(orderRefundDetailDto);
        }
    }
}
