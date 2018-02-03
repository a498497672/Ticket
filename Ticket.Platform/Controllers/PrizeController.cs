using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket.Application.Prize;
using Ticket.Model.Prize;

namespace Ticket.Platform.Controllers
{
    public class PrizeController : Controller
    {
        private readonly PrizeFacadeService _weiXinPrizeFacadeService;
        public PrizeController(PrizeFacadeService weiXinPrizeFacadeService)
        {
            _weiXinPrizeFacadeService = weiXinPrizeFacadeService;
        }

        /// <summary>
        /// 抽奖设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = _weiXinPrizeFacadeService.GetPrizeConfig();
            return View(data);
        }

        /// <summary>
        /// 奖品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult PrizeListData()
        {
            var result = _weiXinPrizeFacadeService.GetPrizeList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 添加奖品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AddPrizeData(WeiXinPrizeDTO model)
        {
            model.EnterpriseId = 1;
            model.ScenicId = 1;
            var result = _weiXinPrizeFacadeService.AddPrize(model);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 保存抽奖配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult UpdatePrizeConfigData(WeiXinPrizeConfigDTO model)
        {
            model.EnterpriseId = 1;
            model.ScenicId = 1;
            var result = _weiXinPrizeFacadeService.UpdatePrizeConfig(model);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Update(int id)
        {
            var data = _weiXinPrizeFacadeService.GetPrize(id);
            return View(data);
        }

        public ActionResult UpdatePrizeData(WeiXinPrizeDTO model)
        {
            var result = _weiXinPrizeFacadeService.UpdatePrize(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 中奖查询
        /// </summary>
        /// <returns></returns>
        public ActionResult WinningCheckList()
        {
            var data = _weiXinPrizeFacadeService.GetPrizeItem();
            ViewBag.SelectItems = data;
            return View();
        }

        public ActionResult WinningCheckListData(WeiXinPrizeUserQureyDTO model)
        {
            var result = _weiXinPrizeFacadeService.GetPrizeUserList(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}