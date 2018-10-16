using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MickMvcFrameWork.Controllers
{
    public class DemoController : ApiController
    {
        //
        // GET: /Demo/
        [HttpGet]
        public List<string> Index()
        {
            List<string> list = new List<string>();
            list.Add("001");
            list.Add("002");
            list.Add("003");

            return list;
        }

        [HttpGet]
        public string GetString()
        {
            return "test";
        }

    }
}
