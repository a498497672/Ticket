using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket.Application.User;
using Ticket.Model.WeiXin;

namespace Ticket.Platform.Controllers
{
    public class IntegralController : Controller
    {
        private readonly IntegralFacadeService _integralFacadeService;
        public IntegralController(IntegralFacadeService integralFacadeService)
        {
            _integralFacadeService = integralFacadeService;
        }
        public ActionResult Index()
        {
            var data = _integralFacadeService.Get();
            return View(data);
        }

        public ActionResult Save(IntegralConfigDto model)
        {
            var result = _integralFacadeService.Save(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}