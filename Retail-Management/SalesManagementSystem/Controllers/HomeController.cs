using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using SalesManagementSystem.ViewModels;
using System.Reflection;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SalesManagementSystem.Controllers
{
    /// <summary>
    /// 默认的主页(待删改)
    /// </summary>
   //[UserAuthorize]
    public class HomeController : Controller
    {
        EntityContext db = new EntityContext();
        DataTables table = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "test",
            new string[] { "Users.UserID", "Users.UserName", "Users.LastName", "Users.FirstName", "Users.Tel", "Users.Email" },
            "EntityContext.Users",
            "AjaxHandler", "Home",
            new string[] { "用户ID", "用户名", "姓氏", "名字", "联系电话", "电子邮箱" });

        public ActionResult Index()
        {
            if (Session["CurrentUser"] == null)
            {
                return RedirectToAction("Login", "Session");
            }
            return View();
        }

        public ActionResult About(string modelString)
        {
            ViewBag.DataTable = table;
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error() {
            return View();
        }
    }
}
