using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MickUserFrameWork.Controllers
{
    public class VCTestController : Controller
    {
        //
        // GET: /VCTest/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetLogin()
        {
            string resStr = string.Empty;
            if (Request["txtName"] != string.Empty)
            {
                resStr = "成功。";
            }
            else
            {
                resStr = "失败";
            }
            return Content(resStr);
        }

    }
}
