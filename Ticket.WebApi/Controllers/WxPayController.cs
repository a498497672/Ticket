using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket.Model.Order;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 微信支付
    /// </summary>
    [RoutePrefix("api/WxPay")]
    public class WxPayController : ApiController
    {
        /// <summary>
        /// 支付结果回调
        /// </summary>
        /// <returns></returns>
        [Route("Notify")]
        public IHttpActionResult Notify()
        {
            return Ok();
        }


        /// <summary>
        /// 创建订单--扫一扫微信支付
        /// </summary>
        /// <param name="scenicTicket"></param>
        /// <returns></returns>
        [Route("PostCreateOrder")]
        public IHttpActionResult PostCreateOrder(ScenicTicketDTO scenicTicket)
        {
            //try
            //{
            //    //var result = _scanTicketLogic.CreateOrder(scenicTicket);
            //    if (scenicTicket.PayType == (int)PayType.Wechat)
            //    {
            //        if (result.Success)
            //        {
            //            Logger.Info("下单成功，进行支付,orderNo:" + result.Data.OrderNo);
            //            //下单成功，进行支付
            //            Pay(result.Data.OrderNo, result.Data.TicketNames, result.Data.TotalMoney.ToString());
            //        }
            //        else
            //        {
            //            Logger.Info("下单失败");
            //        }
            //    }
            //    else
            //    {
            //        return Json(result, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Info(ex.Message, ex);
            //}
            //return Content("");
            return Ok();
        }

        ///// <summary>
        ///// 再次支付订单
        ///// </summary>
        ///// <param name="orderNo"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult PayOrder(string orderNo)
        //{
        //    var data = _scanTicketLogic.GetOrder(orderNo);
        //    if (data.Status)
        //    {
        //        Logger.Info("再次支付，进行支付,orderNo:" + data.Data.OrderNo);
        //        //下单成功，进行支付
        //        Pay(data.Data.OrderNo, data.Data.TicketNames, data.Data.TotalMoney.ToString());
        //    }
        //    else
        //    {
        //        Logger.Info("再次支付失败");
        //    }
        //    return Content("");
        //}

        ///// <summary>
        ///// 充值
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Recharge(WeiXinRechargeDto model)
        //{
        //    try
        //    {
        //        System.Web.HttpContext.Current.Session[CookieKey.ScenicId] = model.ScenicId;
        //        var result = new WeiXinRechargeLogic().CreateOrder(model);
        //        if (result.Success)
        //        {
        //            Logger.Info("充值下单成功，进行支付,orderNo:" + result.Data.OrderNo);
        //            //下单成功，进行支付
        //            Pay(result.Data.OrderNo, result.Data.TicketNames, result.Data.TotalMoney.ToString());
        //        }
        //        else
        //        {
        //            Logger.Info("下单失败");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Info(ex.Message, ex);
        //    }
        //    return Content("");
        //}
    }
}
