using Ticket.Core.Repository;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Prize;
using Ticket.Utility.Searchs;

namespace Ticket.Core.Service
{
    public class PrizeConfigService
    {
        private readonly PrizeConfigRepository _weiXinPrizeConfigRepository;
        private readonly PrizeUserService _weiXinPrizeUserService;

        public PrizeConfigService(
            PrizeConfigRepository weiXinPrizeConfigRepository,
            PrizeUserService weiXinPrizeUserService)
        {
            _weiXinPrizeConfigRepository = weiXinPrizeConfigRepository;
            _weiXinPrizeUserService = weiXinPrizeUserService;
        }

        /// <summary>
        /// 获取抽奖配置及用户剩余抽奖次数
        /// </summary>
        /// <param name="scenicId"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public TResult<WeiXinPrizeConfigInfoDTO> GetPrizeConfig(string openId)
        {
            var result = new TResult<WeiXinPrizeConfigInfoDTO>();
            var tbl_WeiXinPrizeConfig = _weiXinPrizeConfigRepository.FirstOrDefault();
            var data = new WeiXinPrizeConfigInfoDTO();
            if (tbl_WeiXinPrizeConfig != null)
            {
                data.Frequency = tbl_WeiXinPrizeConfig.Frequency;
                data.IsEnable = tbl_WeiXinPrizeConfig.IsEnable;
                data.StartDate = tbl_WeiXinPrizeConfig.StartDate.ToString("yyyy-MM-dd");
                data.EndDate = tbl_WeiXinPrizeConfig.EndDate.ToString("yyyy-MM-dd");

                var tbl_WeiXinPrizeUserCount = _weiXinPrizeUserService.GetWeiXinPrizeUserCount(openId, tbl_WeiXinPrizeConfig);
                data.ResidualFrequency = tbl_WeiXinPrizeConfig.Frequency - tbl_WeiXinPrizeUserCount;
                return result.SuccessResult(data);
            }
            return result.FailureResult(null, "没有找到用户抽奖配置信息");
        }



        /// <summary>
        /// 获取抽奖配置
        /// </summary>
        /// <param name="scenicId"></param>
        /// <returns></returns>
        public WeiXinPrizeConfigDTO GetPrizeConfig()
        {
            var result = _weiXinPrizeConfigRepository.FirstOrDefault();
            var data = new WeiXinPrizeConfigDTO();
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
        public TResult UpdatePrizeConfig(WeiXinPrizeConfigDTO model)
        {
            TResult result = new TResult();
            try
            {
                var tbl_WeiXinPrizeConfig = _weiXinPrizeConfigRepository.FirstOrDefault();
                if (tbl_WeiXinPrizeConfig == null)
                {
                    _weiXinPrizeConfigRepository.Add(new Tbl_WeiXinPrizeConfig
                    {
                        EnterpriseId = model.EnterpriseId,
                        ScenicId = model.ScenicId,
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
                    _weiXinPrizeConfigRepository.Update(tbl_WeiXinPrizeConfig);
                }
                return result.SuccessResult("保存成功");
            }
            catch
            {
                return result.FailureResult("保存失败");
            }
        }
    }
}
