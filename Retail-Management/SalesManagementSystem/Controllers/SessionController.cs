using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using System.Web.Security;
using SalesManagementSystem.ViewModels;

namespace SalesManagementSystem.Controllers
{
    /// <summary>
    /// 负责会话：用户登录和注销
    /// </summary>
    public class SessionController : Controller
    {
        EntityContext db = new EntityContext();

        // GET: /Session/Login
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Id">用户id</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
        public ActionResult Login()
        {
            ViewBag.Info = "请输入用户名和密码";
            return View(new Login() { Username = "" });
        }

        // POST: /Session/Login/5
        [HttpPost]
        public ActionResult Login(Login model)
        {
            User user = db.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user != null && user.VerifyPassword(model.Password))
            {
                Session["CurrentUser"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "用户名或密码错误";
            }
            return View(model);
        }

       
        // GET: /Session/Logout
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}

