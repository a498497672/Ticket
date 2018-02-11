using System.Web.Mvc;
using Ticket.Application.Prize;
using Ticket.Model.WeiXin;

namespace Ticket.Platform.Controllers
{
    public class PageSettingController : Controller
    {
        private readonly BannerFacadeService _bannerFacadeService;
        public PageSettingController(BannerFacadeService bannerFacadeService)
        {
            _bannerFacadeService = bannerFacadeService;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult BannerListData()
        {
            var result = _bannerFacadeService.GetList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            ViewBag.ImageDomain = _bannerFacadeService.GetImageDomain();
            return View();
        }

        public ActionResult AddBannerData(BannerDto model)
        {
            model.EnterpriseId = 1;
            model.ScenicId = 1;
            var result = _bannerFacadeService.Add(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            var data = _bannerFacadeService.Get(id);
            ViewBag.ImageDomain = _bannerFacadeService.GetImageDomain();
            return View(data);
        }

        public ActionResult UpdateBannerData(BannerDto model)
        {
            var result = _bannerFacadeService.Update(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MoveUp(int id)
        {
            var result = _bannerFacadeService.MoveUp(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MoveDown(int id)
        {
            var result = _bannerFacadeService.MoveDown(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更改是否上架下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateIsEnable(int id)
        {
            var result = _bannerFacadeService.UpdateIsEnable(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}