using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ticket.Platform.App_Start;

namespace Ticket.Platform.Controllers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    var exception = filterContext.Exception;
        //    var exceptionType = exception.GetType();
        //    //对于Ajax请求，直接返回一个用于封装异常的JsonResult
        //    if (filterContext.HttpContext.Request.IsAjaxRequest())
        //    {
        //        TResult result = new TResult();
        //        if (exceptionType == typeof(SimpleBadRequestException))
        //        {
        //            filterContext.Result = Json(result.FailureResult(exception.Message), JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            filterContext.Result = Json(result.FailureResult("服务器错误，请联系管理员！"), JsonRequestBehavior.AllowGet);
        //        }
        //        //当结果为json时，设置异常已处理
        //        filterContext.ExceptionHandled = true;
        //    }
        //    else
        //    {
        //        ErrorMessage msg = new ErrorMessage(filterContext.Exception, "页面");
        //        msg.ShowException = MvcException.IsExceptionEnabled();

        //        //错误记录

        //        //设置为true阻止golbal里面的错误执行
        //        filterContext.ExceptionHandled = true;
        //        filterContext.Result = new ViewResult()
        //        {
        //            ViewName = "/Views/Error/ISE.cshtml",
        //            ViewData = new ViewDataDictionary<ErrorMessage>(msg)
        //        };

        //        ////否则调用原始设置
        //        //base.OnException(filterContext);
        //    }
        //}

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //    var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
        //    var actionName = filterContext.ActionDescriptor.ActionName.ToLower();
        //    if (controllerName == "login")
        //    {
        //        return;
        //    }
        //    var isAjaxRequst = filterContext.HttpContext.Request.IsAjaxRequest();
        //    #region 验证登录
        //    TResult result = new TResult();
        //    if (UserInfo == null)
        //    {
        //        if (filterContext.HttpContext.Request.IsAjaxRequest())
        //        {
        //            filterContext.Result = Json(result.FailureResult("登录失效,请刷新页面"), JsonRequestBehavior.AllowGet);
        //            return;
        //        }
        //        filterContext.Result = new RedirectResult("/Login/Index");
        //        return;
        //    }
        //    #endregion
        //}


        ///// <summary>
        ///// 用户信息
        ///// </summary>
        //public AdminUserResult UserInfo
        //{
        //    set
        //    {
        //        System.Web.HttpContext.Current.Session[SessionKey.ManagerUserInfo] = value;
        //    }
        //    get
        //    {
        //        AdminUserResult data = System.Web.HttpContext.Current.Session[SessionKey.ManagerUserInfo] as AdminUserResult;
        //        if (data != null)
        //        {
        //            return data;
        //        }
        //        HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[SessionKey.ManagerUserLoginCookie];
        //        if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
        //        {
        //            string des = SecurityDes.DesDecrypt(cookie.Value, SessionKey.ManagerUserLoginCookieKey);
        //            string[] tmpArr = des.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
        //            if (tmpArr.Length == 2)
        //            {
        //                string username = tmpArr[0];
        //                string password = tmpArr[1];
        //                var repository = new BaseRepository();
        //                var adminUser = repository.Get<AdminUser>(new { UserName = username, Password = password });
        //                if (adminUser != null)
        //                {
        //                    data = new AdminUserResult
        //                    {
        //                        UserId = adminUser.Id,
        //                        UserName = adminUser.UserName,
        //                        RealName = adminUser.RealName
        //                    };
        //                    System.Web.HttpContext.Current.Session[SessionKey.ManagerUserInfo] = data;
        //                }
        //            }
        //        }
        //        return data;
        //    }
        //}

        ///// <summary>
        ///// 清楚SESSION and cookie
        ///// </summary>
        //public void ClearSessionAndCookie()
        //{
        //    System.Web.HttpContext.Current.Session.Clear();

        //    HttpCookie hc1 = new HttpCookie(SessionKey.ManagerUserLoginCode, null);
        //    hc1.Expires = DateTime.Now.AddDays(-1);
        //    System.Web.HttpContext.Current.Response.Cookies.Add(hc1);

        //    HttpCookie hc2 = new HttpCookie(SessionKey.ManagerUserLoginCookie, null);
        //    hc2.Expires = DateTime.Now.AddDays(-1);
        //    System.Web.HttpContext.Current.Response.Cookies.Add(hc2);

        //    System.Web.HttpContext.Current.Request.Cookies.Clear();
        //}
    }
}