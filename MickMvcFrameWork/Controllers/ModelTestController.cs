using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MickUserFrameWork.Models;

namespace MickUserFrameWork.Controllers
{
    public class ModelTestController : Controller
    {
        //
        // GET: /ModelTest/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 模型绑定相关
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index([Bind(Prefix="p")]Person person)
        {

            this.TempData["msg"] = person.FirstName + "," + person.LastName+","+person.HomeAddress.AddressValue;

            return View();
        }

        public ActionResult Index2()
        {
            Person p = new Person();

            return View(p);
        }

        /// <summary>
        /// 控制模型绑定来源相关
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Index2")]
        public ActionResult Index2Post()
        {
            Person p = new Person();

            //使用默认来源更新模型
            //UpdateModel(p);

            //使用FormValueProvider提供程序，此为默认，即只能从form中获取
            UpdateModel(p, new FormValueProvider(this.ControllerContext));

            //使用网站路由提供程序，从网站路由信息中获取
            //RouteDataValueProvider rdvp = new RouteDataValueProvider(this.ControllerContext);
            //UpdateModel(p, rdvp);

            //使用名值对提供程序，从url名值对中获取
            //QueryStringValueProvider qsvp = new QueryStringValueProvider(this.ControllerContext);
            //UpdateModel(p, qsvp);


            this.TempData["msg"] = p.ID;

            return View(p);
        }


        /// <summary>
        /// 模型绑定相关3
        /// </summary>
        /// <returns></returns>
        public ActionResult Index3()
        {
            return View();
        }

        /// <summary>
        /// 模型绑定3，验证页面数据是否通过方法的入參传送
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Index3")]
        public ActionResult Index3Post(Person person)
        {
            //Person person = new Person();
            this.TempData["msg"] = person.FirstName + "," + person.LastName + "," + person.HomeAddress.AddressValue;

            return View();
        }

    }
}
