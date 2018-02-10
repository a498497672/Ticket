using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ticket.Application.User;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 积分
    /// </summary>
    [RoutePrefix("api/Integral")]
    public class IntegralController : ApiController
    {
        private readonly IntegralFacadeService _integralFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="integralFacadeService"></param>
        public IntegralController(IntegralFacadeService integralFacadeService)
        {
            _integralFacadeService = integralFacadeService;
        }


        /// <summary>
        /// 获取积分明细
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("GetIntegralDetails")]
        [ResponseType(typeof(TPageResult<WeiXinIntegralDetailsDto>))]
        public IHttpActionResult GetIntegralDetails(string openId, int page, int limit)
        {
            var list = _integralFacadeService.GetList(new WeiXinIntegralDetailsQueryDto
            {
                OpenId = openId,
                Page = page,
                Limit = limit
            });
            var result = new TPageResult<WeiXinIntegralDetailsDto>();
            return Ok(result.SuccessResult(list.Data, list.TotalCount));
        }

        /// <summary>
        /// 获取积分配置
        /// </summary>
        /// <returns></returns>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("GetIntegralConfig")]
        [ResponseType(typeof(TResult<List<IntegralConfigViewDto>>))]
        public IHttpActionResult GetIntegralConfig()
        {
            var list= _integralFacadeService.GetIntegralConfigList();
            var integralConfigViewDtos = Mapper.Map<List<IntegralConfigViewDto>>(list);
            var result = new TResult<List<IntegralConfigViewDto>>();
            return Ok(result.SuccessResult(integralConfigViewDtos));
        }
    }
}
