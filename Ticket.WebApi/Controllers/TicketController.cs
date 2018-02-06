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
    /// 
    /// </summary>
    [RoutePrefix("api/Ticket")]
    public class TicketController : ApiController
    {
        private readonly ScenicFacadeService _scenicFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenicFacadeService"></param>
        public TicketController(ScenicFacadeService scenicFacadeService)
        {
            _scenicFacadeService = scenicFacadeService;
        }

        /// <summary>
        /// 获取门票列表
        /// </summary>
        /// <param name="playTime">游玩日期.</param>
        /// <response code="200">成功.</response>
        /// <response code="404">数据不存在.</response>
        [Route("GetTicketList")]
        [ResponseType(typeof(TResult<List<TicketViewDto>>))]
        public IHttpActionResult GetTicketList(DateTime playTime)
        {
            var ticket = _scenicFacadeService.GetTicketList(playTime);
            var ticketViewDtos = Mapper.Map<List<TicketViewDto>>(ticket);
            var result = new TResult<List<TicketViewDto>>();
            return Ok(result.SuccessResult(ticketViewDtos));
        }
    }
}
