using Norway.Core;
using Norway.Core.Users;
using Norway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Norway.Areas.Control.Controllers
{
    [AdminAuthorize]
    public class RoleController : Controller
    {
        private RoleManager roleManager = new RoleManager();

        // GET: Control/Role
        public ActionResult Index()
        {
            return View();
        }
    }
}