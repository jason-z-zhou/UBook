using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SalesManagementSystem.Models;
using System.Data.Entity.Infrastructure;
using SalesManagementSystem.ViewModels;


namespace SalesManagementSystem.Controllers
{
   

    /// <summary>
    /// 用于处理用户数据
    /// </summary>
   // [UserAuthorize]
    public class UserController : Controller
    {
        private EntityContext db = new EntityContext();
        private DataTables table = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "test",
            new string[] { "Users.UserName", "Users.LastName", "Users.FirstName", "Users.Tel", "Users.Email", "Users.UserID" },
            "EntityContext.Users",
            "AjaxHandler", "User",
            new string[] { "用户名", "姓氏", "名字", "联系电话", "电子邮箱", "操作" },
            new string[] { "15%", "10%", "10%", "20%", "20%", "50%"});

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        // GET: /User/
        /// <summary>
        /// 显示用户目录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.DataTable = table;
            return View();
        }

        // GET: /User/Details/5
        /// <summary>
        /// 显示用户细节
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            User user = db.Users.Find(id);
            var checkedList = new List<string>() { "" };
            foreach(var role in db.Roles.ToList())
            {
                if (user.Roles.Contains(role))
                {
                    checkedList.Add ("checked=\"checked\"");
                }
                else
                {
                    checkedList.Add ("");
                }
            }
            ViewBag.CheckedList = checkedList;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        /// <summary>
        /// 管理员增加用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // 
        // POST: /Movies/Create 

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (Role role in user.Roles) {
                        db.Roles.Attach(role);
                    }
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "tianjiacuowu！");
            }
            return View(user);
        }

        // GET: /User/Edit/5
        /// <summary>
        /// 管理员修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);
            var checkedList = new List<string>() { "" };
            foreach (var role in db.Roles.ToList())
            {
                if (user.Roles.Contains(role))
                {
                    checkedList.Add("checked=\"checked\"");
                }
                else
                {
                    checkedList.Add("");
                }
            }
            ViewBag.CheckedList = checkedList;
            ViewBag.Roles = db.Roles.OrderBy(g => g.RoleName).ToList();
            ViewBag.Stores = db.Stores.OrderBy(a => a.StoreName).ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
           try
           {
               var user = db.Users.Find(model.UserID);
               user.Tel = model.Tel;
               user.Comment = model.Comment;
               user.Email = model.Email;
               user.FirstName = model.FirstName;
               user.LastName = model.LastName;
               user.Roles.Clear();
               foreach (Role role in model.Roles)
               {
                   user.Roles.Add(db.Roles.Find(role.RoleID));
               }
               db.Entry(user).State = EntityState.Modified;
               db.SaveChanges();
           }
           catch (Exception)
           {
               ModelState.AddModelError("", "Error occurred while Modifying store, please check your information!");
           }
            ViewBag.Roles = db.Roles.OrderBy(g => g.RoleName).ToList();
            ViewBag.Stores = db.Stores.OrderBy(a => a.StoreName).ToList();
            return RedirectToAction("Details", new { id = model.UserID }); 
        }

        // GET: /User/Delete/5
        /// <summary>
        /// 管理员删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);


        }
        // HttpPost, ActionName("Delete")] 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        /// <summary>
        /// 管理员修改用户密码
        /// </summary>
        /// <returns></returns>

        public ActionResult ChangePassword(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.UserName = user.UserName;
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new ChangePassword() { UserID = id });
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            User user = db.Users.Find(model.UserID);
            user.Password = model.NewPassword;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        /// <summary>
        /// 用户修改自己密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyPassword()
        {

            User user = (User)Session["CurrentUser"];
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new ChangePassword() { UserID = user.UserID });
        }

        /// <summary>
        /// 用户修改自己个人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePersonelInfo() 
        {
            User user = (User)Session["CurrentUser"];

            return View(user);
        
        }

        [HttpPost]
        public ActionResult ChangePersonelInfo(User model)
        {
            try
            {
                var user = db.Users.Find(((User)Session["CurrentUser"]).UserID);
                user.Tel = model.Tel;
                user.Comment = model.Comment;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while Modifying store, please check your information!");
            }
            ViewBag.Roles = db.Roles.OrderBy(g => g.RoleName).ToList();
            ViewBag.Stores = db.Stores.OrderBy(a => a.StoreName).ToList();
            return RedirectToAction("Details", new { id = model.UserID });
        }
    }
}

 





