using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket.Application.Order;
using Ticket.Model.Order;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        private readonly OrderFacadeService _orderFacadeService;
        private readonly OrderDetailFacadeService _orderDetailFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderFacadeService"></param>
        /// <param name="orderDetailFacadeService"></param>
        public OrderController(
            OrderFacadeService orderFacadeService,
            OrderDetailFacadeService orderDetailFacadeService)
        {
            _orderFacadeService = orderFacadeService;
            _orderDetailFacadeService = orderDetailFacadeService;
        }

        /// <summary>
        /// 获取订单列表 -- 门票
        /// </summary>
        /// <param name="openId">微信用户唯一标识</param>
        /// <returns></returns>
        [Route("TicketList")]
        public IHttpActionResult GetOrderTicketList(string openId)
        {
            var orders = _orderFacadeService.GetListForTicket(openId);
            var orderViewDtos = Mapper.Map<List<OrderViewDto>>(orders);
            var result = new TResult<List<OrderViewDto>>();
            return Ok(result.SuccessResult(orderViewDtos));
        }

        /// <summary>
        /// 获取订单详情  -- 门票
        /// </summary>
        /// <param name="openId">微信用户唯一标识</param>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        [Route("Detail")]
        public IHttpActionResult GetOrderDetail(string orderNo)
        {
            var orderDetail = _orderDetailFacadeService.Get(orderNo);
            var orderDetailViewDto = Mapper.Map<List<OrderDetailViewDto>>(orderDetail);
            var result = new TResult<List<OrderDetailViewDto>>();
            return Ok(result.SuccessResult(orderDetailViewDto));
        }

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="orderRefundDto"></param>
        /// <returns></returns>
        [Route("Refund")]
        public IHttpActionResult PostRefundOrder(OrderRefundDto orderRefundDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            _orderDetailFacadeService.Refund(orderRefundDto.OrderNo);
            var result = new TResult();
            return Ok(result.SuccessResult());
        }
    }
}
