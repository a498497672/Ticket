using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ticket.Application.Scenic;
using Ticket.Model.Scenic;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 景区
    /// </summary>
    [RoutePrefix("api/Scenic")]
    public class ScenicController : ApiController
    {
        private readonly ScenicFacadeService _scenicFacadeService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenicFacadeService"></param>
        public ScenicController(ScenicFacadeService scenicFacadeService)
        {
            _scenicFacadeService = scenicFacadeService;
        }

        /// <summary>
        /// 查询景区
        /// </summary>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("")]
        [ResponseType(typeof(TResult<ScenicViewDto>))]
        public IHttpActionResult Get()
        {
            var scenic = _scenicFacadeService.Get();
            if (scenic == null)
            {
                return NotFound();
            }
            var scenicViewDto = Mapper.Map<ScenicViewDto>(scenic);
            scenicViewDto.LyUserId = "1243350";
            var result = new TResult<ScenicViewDto>();
            return Ok(result.SuccessResult(scenicViewDto));
        }
    }
}
