using System.Collections.Generic;
using Ticket.Core.Service;
using Ticket.Model.Common;
using Ticket.Model.Prize;
using Ticket.Utility.Searchs;

namespace Ticket.Application.Prize
{
    public class PrizeFacadeService
    {
        private readonly WeiXinPrizeService _weiXinPrizeService;
        private readonly WeiXinPrizeConfigService _weiXinPrizeConfigService;
        private readonly WeiXinPrizeUserService _weiXinPrizeUserService;

        public PrizeFacadeService(
            WeiXinPrizeService weiXinPrizeService,
            WeiXinPrizeConfigService weiXinPrizeConfigService,
            WeiXinPrizeUserService weiXinPrizeUserService)
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
        public TPageResult<WeiXinPrizeViewDTO> GetPrizeList()
        {
            return _weiXinPrizeService.GetPrizeList();
        }

        public List<SelectItemDto> GetPrizeItem()
        {
            return _weiXinPrizeService.GetPrizeItem();
        }

        public WeiXinPrizeDTO GetPrize(int id)
        {
            return _weiXinPrizeService.GetPrize(id);
        }

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult AddPrize(WeiXinPrizeDTO model)
        {
            return _weiXinPrizeService.AddPrize(model);
        }

        /// <summary>
        /// 修改奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrize(WeiXinPrizeDTO model)
        {
            return _weiXinPrizeService.UpdatePrize(model);
        }

        /// <summary>
        /// 获取抽奖配置及用户剩余抽奖次数
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public TResult<WeiXinPrizeConfigInfoDTO> GetPrizeConfig(string openId)
        {
            return _weiXinPrizeConfigService.GetPrizeConfig(openId);
        }



        /// <summary>
        /// 获取抽奖配置
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public WeiXinPrizeConfigDTO GetPrizeConfig()
        {
            return _weiXinPrizeConfigService.GetPrizeConfig();
        }

        /// <summary>
        /// 保存抽奖配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrizeConfig(WeiXinPrizeConfigDTO model)
        {
            return _weiXinPrizeConfigService.UpdatePrizeConfig(model);
        }

        /// <summary>
        /// 获取奖品列表
        /// </summary>
        /// <param name="scenicId">景区id</param>
        /// <returns></returns>
        public TPageResult<WeiXinPrizeUserViewDTO> GetPrizeUserList(WeiXinPrizeUserQureyDTO model)
        {
            return _weiXinPrizeUserService.GetPrizeUserList(model);
        }
    }
}
