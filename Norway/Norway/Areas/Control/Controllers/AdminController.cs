using Norway.Areas.Control.Models;
using Norway.Core;
using Norway.Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Norway.Areas.Control.Controllers
{
    public class AdminController : Controller
    {
        private AdministratorManager adminManager = new AdministratorManager();

        // GET: Control/Admin
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                string _passowrd = Security.SHA256(loginViewModel.Password);
                var _response = adminManager.Verify(loginViewModel.Accounts, _passowrd);
                if (_response.Code == 1)
                {
                    var _admin = adminManager.Find(loginViewModel.Accounts);
                    Session.Add("AdminID", _admin.AdministratorID);
                    Session.Add("Accounts", _admin.Accounts);
                    _admin.LoginTime = DateTime.Now;
                    _admin.LoginIP = Request.UserHostAddress;
                    adminManager.Update(_admin);
                    return RedirectToAction("Index", "Home");
                }
                else if (_response.Code == 2) ModelState.AddModelError("Accounts", _response.Message);
                else if (_response.Code == 3) ModelState.AddModelError("Password", _response.Message);
                else ModelState.AddModelError("", _response.Message);
            }
            return View(loginViewModel);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}