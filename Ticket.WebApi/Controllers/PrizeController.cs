using System.Collections.Generic;
using System.Web.Http;
using Ticket.Application.Prize;
using Ticket.Model.Common;
using Ticket.Model.Prize;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 抽奖
    /// </summary>
    [RoutePrefix("api/Prize")]
    public class PrizeController : ApiController
    {
        private readonly PrizeFacadeService _prizeFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prizeFacadeService"></param>
        public PrizeController(PrizeFacadeService prizeFacadeService)
        {
            _prizeFacadeService = prizeFacadeService;
        }

        /// <summary>
        /// 开始抽奖
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [Route("DrawStart")]
        public IHttpActionResult PostDrawStart(string openId)
        {
            var data = _prizeFacadeService.DrawStart(openId);
            var result = new TResult<PrizeWinningDto>();
            return Ok(result.SuccessResult(data));
        }

        /// <summary>
        /// 获取转盘奖品
        /// </summary>
        /// <returns></returns>
        [Route("PrizeItem")]
        public IHttpActionResult GetPrizeItem()
        {
            var data = _prizeFacadeService.GetPrizeItem();
            var result = new TResult<List<SelectItemDto>>();
            return Ok(result.SuccessResult(data));
        }

        /// <summary>
        /// 获取抽奖配置
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [Route("GetPrizeConfig")]
        public IHttpActionResult GetPrizeConfig(string openId)
        {
            var data = _prizeFacadeService.GetPrizeConfig(openId);
            var result = new TResult<PrizeConfigInfoDto>();
            return Ok(result.SuccessResult(data));
        }

        /// <summary>
        /// 获取用户中奖数据
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        [Route("GetPrizeUserList")]
        public IHttpActionResult GetPrizeUserList(string openId)
        {
            var data = _prizeFacadeService.GetPrizeUserList(openId);
            var result = new TResult<List<PrizeUserListDto>>();
            return Ok(result.SuccessResult(data));
        }

        /// <summary>
        /// 获取我的优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="isUse">是否使用（true 已使用，false 未使用）</param>
        /// <returns></returns>
        [Route("GetPrizeUserForCouponList")]
        public IHttpActionResult GetPrizeUserForCouponList(string openId, bool isUse)
        {
            var data = _prizeFacadeService.GetPrizeUserForCouponList(openId, isUse);
            var result = new TResult<List<PrizeUserListDto>>();
            return Ok(result.SuccessResult(data));
        }

        /// <summary>
        /// 获取可用优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="amount">订单金额</param>
        /// <returns></returns>
        [Route("GetAvailableCouponsList")]
        public IHttpActionResult GetAvailableCouponsList(string openId, decimal amount)
        {
            var data = _prizeFacadeService.GetAvailableCouponsList(openId, amount);
            var result = new TResult<List<AvailableCouponsDto>>();
            return Ok(result.SuccessResult(data));
        }
    }
}
