using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Service;
using Ticket.EntityFramework.Entities;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.Application.User
{
    /// <summary>
    /// 积分
    /// </summary>
    public class IntegralFacadeService
    {
        private readonly IntegralConfigService _integralConfigService;
        private readonly IntegralDetailsService _integralDetailsService;
        public IntegralFacadeService(
            IntegralConfigService integralConfigService,
            IntegralDetailsService integralDetailsService)
        {
            _integralConfigService = integralConfigService;
            _integralDetailsService = integralDetailsService;
        }

        /// <summary>
        /// 获取积分明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PagedResult<WeiXinIntegralDetailsDto> GetList(WeiXinIntegralDetailsQueryDto model)
        {
            return _integralDetailsService.GetList(model);
        }

        /// <summary>
        /// 获取积分配置
        /// </summary>
        /// <returns></returns>
        public List<Tbl_WeiXinIntegralConfig> GetIntegralConfigList()
        {
            return _integralConfigService.GetList();
        }


        /// <summary>
        /// 获取积分
        /// </summary>
        /// <returns></returns>
        public WeiXinIntegralConfigDto Get()
        {
            return _integralConfigService.Get();
        }

        /// <summary>
        /// 保存积分
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TResult Save(WeiXinIntegralConfigDto model)
        {
            return _integralConfigService.Save(model);
        }
    }
}
