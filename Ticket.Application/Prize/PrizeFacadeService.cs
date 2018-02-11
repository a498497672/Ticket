using System.Collections.Generic;
using Ticket.Core.Service;
using Ticket.Model.Common;
using Ticket.Model.Prize;
using Ticket.Utility.Searchs;
using Ticket.Utility.UnitOfWorks;

namespace Ticket.Application.Prize
{
    public class PrizeFacadeService
    {
        private readonly PrizeService _weiXinPrizeService;
        private readonly PrizeConfigService _weiXinPrizeConfigService;
        private readonly PrizeUserService _weiXinPrizeUserService;

        public PrizeFacadeService(
            PrizeService weiXinPrizeService,
            PrizeConfigService weiXinPrizeConfigService,
            PrizeUserService weiXinPrizeUserService)
        {
            _weiXinPrizeService = weiXinPrizeService;
            _weiXinPrizeConfigService = weiXinPrizeConfigService;
            _weiXinPrizeUserService = weiXinPrizeUserService;
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<PrizeViewDto> GetPrizeList()
        {
            return _weiXinPrizeService.GetPrizeList();
        }

        public List<SelectItemDto> GetPrizeItem()
        {
            return _weiXinPrizeService.GetPrizeItem();
        }

        public PrizeDto GetPrize(int id)
        {
            return _weiXinPrizeService.GetPrize(id);
        }

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult AddPrize(PrizeDto model)
        {
            return _weiXinPrizeService.AddPrize(model);
        }

        /// <summary>
        /// 修改奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrize(PrizeDto model)
        {
            return _weiXinPrizeService.UpdatePrize(model);
        }

        /// <summary>
        /// 获取抽奖配置及用户剩余抽奖次数
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public PrizeConfigInfoDto GetPrizeConfig(string openId)
        {
            return _weiXinPrizeConfigService.GetPrizeConfig(openId);
        }

        /// <summary>
        /// 获取抽奖配置
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public PrizeConfigDto GetPrizeConfig()
        {
            return _weiXinPrizeConfigService.GetPrizeConfig();
        }

        /// <summary>
        /// 保存抽奖配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrizeConfig(PrizeConfigDto model)
        {
            return _weiXinPrizeConfigService.UpdatePrizeConfig(model);
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<PrizeUserViewDto> GetPrizeUserList(PrizeUserQureyDto model)
        {
            return _weiXinPrizeUserService.GetPrizeUserList(model);
        }

        /// <summary>
        /// 开始抽奖
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public PrizeWinningDto DrawStart(string openId)
        {
            var prizeWinningDto = new PrizeWinningDto();
            using (var unitOfWork = new UnitOfWork())
            {
                prizeWinningDto = _weiXinPrizeService.DrawStart(openId);
                unitOfWork.Commit();
            }
            return prizeWinningDto;
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<PrizeUserListDto> GetPrizeUserList(string openId)
        {
            return _weiXinPrizeUserService.GetPrizeUserList(openId);
        }

        /// <summary>
        /// 获取我的优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="IsUse">是否使用（过期的包含在已使用中）</param>
        /// <returns></returns>
        public List<PrizeUserListDto> GetPrizeUserForCouponList(string openId, bool IsUse)
        {
            return _weiXinPrizeUserService.GetPrizeUserForCouponList(openId,IsUse);
        }

        /// <summary>
        /// 获取可以优惠卷
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="amount">订单金额</param>
        /// <returns></returns>
        public List<AvailableCouponsDto> GetAvailableCouponsList(string openId, decimal amount)
        {
            return _weiXinPrizeUserService.GetAvailableCouponsList(openId, amount);
        }
    }
}
