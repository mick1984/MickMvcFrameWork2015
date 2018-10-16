using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisBase;
using MisBase.Users;
using MickUserFrameWork.Models;

namespace MickMvcFrameWork.Controllers
{
    public class MobileController : Controller
    {
        //
        // GET: /Mobile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataList()
        {
            return View();
        }

    }
}
