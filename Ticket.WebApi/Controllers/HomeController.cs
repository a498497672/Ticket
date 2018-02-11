using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticket.Application.Prize;
using Ticket.Model.WeiXin;
using Ticket.Utility.Searchs;

namespace Ticket.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private readonly BannerFacadeService _bannerFacadeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bannerFacadeService"></param>
        public HomeController(BannerFacadeService bannerFacadeService)
        {
            _bannerFacadeService = bannerFacadeService;
        }

        /// <summary>
        /// 获取轮播图列表
        /// </summary>
        /// <returns></returns>
        [Route("GetBannerItems")]
        public IHttpActionResult GetBannerItems()
        {
            var data = _bannerFacadeService.GetItems();
            var result = new TResult<List<BannerItemDto>>();
            return Ok(result.SuccessResult(data));
        }
    }
}
