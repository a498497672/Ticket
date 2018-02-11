using System.Web.Mvc;
using Ticket.Application.Member;
using Ticket.Application.Prize;
using Ticket.EntityFramework.Entities;
using Ticket.Model.Member;
using Ticket.Utility.Searchs;

namespace Ticket.Platform.Controllers
{
    public class MemberTypeController : Controller
    {
        private readonly MemberTypeFacadeService _memberTypeFacadeService;
        private readonly BannerFacadeService _bannerFacadeService;
        public MemberTypeController(
            MemberTypeFacadeService memberTypeFacadeService,
            BannerFacadeService bannerFacadeService)
        {
            _memberTypeFacadeService = memberTypeFacadeService;
            _bannerFacadeService = bannerFacadeService;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult ListData()
        {
            var list = _memberTypeFacadeService.GetList();
            var result = new TPageResult<Tbl_MemberType>();
            return Json(result.SuccessResult(list, list.Count), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            ViewBag.ImageDomain = _bannerFacadeService.GetImageDomain();
            return View();
        }

        public ActionResult AddData(Tbl_MemberType model)
        {
            _memberTypeFacadeService.Add(model);
            var result = new TResult();
            return Json(result.SuccessResult(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            ViewBag.ImageDomain = _bannerFacadeService.GetImageDomain();
            var data = _memberTypeFacadeService.Get(id);
            return View(new MemberTypeViewDto
            {
                Id = data.Id,
                Name = data.Name,
                Discount = data.Discount,
                RequiredPoint = data.RequiredPoint
            });
        }

        public ActionResult UpdateData(Tbl_MemberType model)
        {
            _memberTypeFacadeService.Update(model);
            var result = new TResult();
            return Json(result.SuccessResult(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteData(int id)
        {
            _memberTypeFacadeService.Delete(id);
            var result = new TResult();
            return Json(result.SuccessResult(), JsonRequestBehavior.AllowGet);
        }
    }
}