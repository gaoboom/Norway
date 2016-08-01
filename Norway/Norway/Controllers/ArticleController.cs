using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Norway.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 文章列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}