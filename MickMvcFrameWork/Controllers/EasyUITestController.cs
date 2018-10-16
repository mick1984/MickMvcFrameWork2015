using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NJSON = Newtonsoft.Json;
using MickUserFrameWork.Models;

namespace MickUserFrameWork.Controllers
{
    public class EasyUITestController : Controller
    {
        //
        // GET: /EasyUITest/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult DateBox()
        {
            return View();
        }

        public ActionResult DataGrid()
        {
            List<Person> list = new List<Person>();

            Person p = new Person();
            p.FirstName = "001";
            list.Add(p);

            Person p2 = new Person();
            p2.FirstName = "002";
            list.Add(p2);

            NJSON.JsonSerializer json = new NJSON.JsonSerializer();
            string resStr = NJSON.JsonConvert.SerializeObject(p);

            return View();
        }

        public JsonResult GetDataGrid(string page,string rows)
        {
            ZhiquHisContext hisContext = new ZhiquHisContext();

            List<gjjZhiquHistory> list = hisContext.GetZhiquHis2(string.Empty);

            int pagesizeI = int.Parse(rows);//Request["rows"]
            int pagenumI = int.Parse(page);//Request["page"]

            var json = new
            {
                total = list.Count,
                rows = list.Skip((pagenumI-1)*pagesizeI).Take(pagesizeI).ToArray()
            };

            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dialog()
        {
            return View();
        }

    }
}
