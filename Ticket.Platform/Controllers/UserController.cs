using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticket.Platform.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}