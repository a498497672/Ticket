using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket.Application.Prize;

namespace Ticket.Platform.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BannerFacadeService _bannerFacadeService;

        public DashboardController(BannerFacadeService bannerFacadeService)
        {
            _bannerFacadeService = bannerFacadeService;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}