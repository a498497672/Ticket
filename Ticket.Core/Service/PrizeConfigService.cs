using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Prize;
using Ticket.Utility.Exceptions;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class PrizeConfigService
    {
        private readonly PrizeConfigRepository _prizeConfigRepository;
        private readonly PrizeUserService _prizeUserService;

        public PrizeConfigService(
            PrizeConfigRepository prizeConfigRepository,
            PrizeUserService prizeUserService)
        {
            _prizeConfigRepository = prizeConfigRepository;
            _prizeUserService = prizeUserService;
        }

        /// <summary>
        /// 获取抽奖配置及用户剩余抽奖次数
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public PrizeConfigInfoDto GetPrizeConfig(string openId)
        {
            var tbl_WeiXinPrizeConfig = _prizeConfigRepository.FirstOrDefault();        
            if (tbl_WeiXinPrizeConfig != null)
            {
                throw new SimplePromptException("请联系管理员设置抽奖信息");
            }
            var data = new PrizeConfigInfoDto();
            data.Frequency = tbl_WeiXinPrizeConfig.Frequency;
            data.IsEnable = tbl_WeiXinPrizeConfig.IsEnable;
            data.StartDate = tbl_WeiXinPrizeConfig.StartDate.ToString("yyyy-MM-dd");
            data.EndDate = tbl_WeiXinPrizeConfig.EndDate.ToString("yyyy-MM-dd");

            var tbl_WeiXinPrizeUserCount = _prizeUserService.GetWeiXinPrizeUserCount(openId, tbl_WeiXinPrizeConfig);
            data.ResidualFrequency = tbl_WeiXinPrizeConfig.Frequency - tbl_WeiXinPrizeUserCount;
            return data;
        }

        /// <summary>
        /// 获取抽奖配置
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public PrizeConfigDto GetPrizeConfig()
        {
            var result = _prizeConfigRepository.FirstOrDefault();
            var data = new PrizeConfigDto();
            if (result != null)
            {
                data.Frequency = result.Frequency;
                data.IsEnable = result.IsEnable;
                data.StartDate = result.StartDate;
                data.EndDate = result.EndDate;
                data.StartDateStr = result.StartDate.ToString("yyyy-MM-dd");
                data.EndDateStr = result.EndDate.ToString("yyyy-MM-dd");
            }
            return data;
        }

        /// <summary>
        /// 保存抽奖配置信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult UpdatePrizeConfig(PrizeConfigDto model)
        {
            TResult result = new TResult();
            try
            {
                var tbl_WeiXinPrizeConfig = _prizeConfigRepository.FirstOrDefault();
                if (tbl_WeiXinPrizeConfig == null)
                {
                    _prizeConfigRepository.Add(new Tbl_PrizeConfig
                    {
                        Frequency = model.Frequency,
                        IsEnable = model.IsEnable,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    });
                }
                else
                {
                    tbl_WeiXinPrizeConfig.Frequency = model.Frequency;
                    tbl_WeiXinPrizeConfig.IsEnable = model.IsEnable;
                    tbl_WeiXinPrizeConfig.StartDate = model.StartDate;
                    tbl_WeiXinPrizeConfig.EndDate = model.EndDate;
                    _prizeConfigRepository.Update(tbl_WeiXinPrizeConfig);
                }
                return result.SuccessResult("保存成功");
            }
            catch
            {
                return result.FailureResult("保存失败");
            }
        }

        /// <summary>
        /// 检查是否可以抽奖
        /// </summary>
        /// <returns></returns>
        public Tbl_PrizeConfig CheckIsDraw()
        {
            var tbl_PrizeConfig = _prizeConfigRepository.FirstOrDefault();
            if (tbl_PrizeConfig == null)
            {
                throw new SimplePromptException("抽奖系统未开启");
            }
            if (!tbl_PrizeConfig.IsEnable)
            {
                throw new SimplePromptException("抽奖系统未开启");
            }
            return tbl_PrizeConfig;
        }
    }
}
