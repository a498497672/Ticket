using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket.Application.Order;
using Ticket.Model.Enum;
using Ticket.Model.Order;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 微信支付
    /// </summary>
    [RoutePrefix("api/WxPay")]
    public class WxPayController : ApiController
    {
        private readonly OrderFacadeService _orderFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderFacadeService"></param>
        public WxPayController(OrderFacadeService orderFacadeService)
        {
            _orderFacadeService = orderFacadeService;

        }
        /// <summary>
        /// 支付结果回调
        /// </summary>
        /// <returns></returns>
        [Route("Notify")]
        public IHttpActionResult Notify()
        {
            _orderFacadeService.PayNotify();
            return Ok();
        }


        /// <summary>
        /// 创建订单--微信支付
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        [Route("PostCreateOrder")]
        public IHttpActionResult PostCreateOrder(OrderCreateDto orderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var orderCreateViewDto = _orderFacadeService.Create(orderCreateDto);
            var result = new TResult<OrderCreateViewDto>();
            return Ok(result.SuccessResult(orderCreateViewDto));
        }

        /// <summary>
        /// 余额支付
        /// </summary>
        /// <param name="orderCreateDto"></param>
        /// <returns></returns>
        [Route("BalancePay")]
        public IHttpActionResult PostBalancePay(OrderCreateDto orderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var orderNo = _orderFacadeService.BalancePay(orderCreateDto);
            var result = new TResult<string>();
            return Ok(result.SuccessResult(orderNo));
        }

        /// <summary>
        /// 再次支付订单
        /// </summary>
        /// <param name="orderPayAgainDto"></param>
        /// <returns></returns>
        [Route("BalancePay")]
        public IHttpActionResult PostPayAgain(OrderPayAgainDto orderPayAgainDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var tbl_Order = _orderFacadeService.Get(orderPayAgainDto.OrderNo);
            if (tbl_Order == null)
            {
                return NotFound();
            }
            var orderCreateViewDto = _orderFacadeService.PayAgain(tbl_Order);
            var result = new TResult<OrderCreateViewDto>();
            return Ok(result.SuccessResult(orderCreateViewDto));
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="orderRechargeDto"></param>
        /// <returns></returns>
        [Route("Recharge")]
        public IHttpActionResult PostRecharge(OrderRechargeDto orderRechargeDto)
        {
            if (!ModelState.IsValid)
            {
                var message = ModelState.BuildErrorMessage();
                throw new SimplePromptException(message);
            }
            var orderCreateViewDto = _orderFacadeService.Recharge(orderRechargeDto);
            var result = new TResult<OrderCreateViewDto>();
            return Ok(result.SuccessResult(orderCreateViewDto));
        }
    }
}
