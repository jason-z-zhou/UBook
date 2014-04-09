using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using System.Data.Entity.Infrastructure;
using SalesManagementSystem.ViewModels;

namespace SalesManagementSystem.Controllers
{
    public class AssessReportController : Controller
    {
        private EntityContext db = new EntityContext();
        private DataTables AssessReportTable = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "AssessReport",
            new string[] { "SqlServer.DATENAME('dd' ,AssessReports.AssessTime) + '/' + SqlServer.DATENAME('mm' ,AssessReports.AssessTime) + '/' + SqlServer.DATENAME('yyyy' ,AssessReports.AssessTime)", "AssessReports.Reviewer.UserName", "AssessReports.StoreID", "AssessReports.Store.StoreName", "SqlServer.DATENAME('yyyy' ,AssessReports.AssessTime)", "SqlServer.DATENAME('mm' ,AssessReports.AssessTime)", "SqlServer.DATENAME('dd' ,AssessReports.AssessTime)" },
            "EntityContext.AssessReports",
            "AjaxHandler", "AssessReport",
            new string[] { "销售日期（日/月/年）", "评分员姓名", "销售点编号", "销售点名", "年", "月", "日" });

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            AssessReportTable.Where = "AssessReports.Store.StoreID = " + Session["ViewStoreID"].ToString();
            return Json(AssessReportTable.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            DataTables table;
            User user = (User)Session["CurrentUser"];
            user = db.Users.Find(user.UserID);
            if (db.Roles.Find(1).Users.Contains(user) || db.Roles.Find(6).Users.Contains(user))
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "Stores.StoreName", "Stores.Address", "Stores.Region.RegionName", "Stores.StoreID" },
        "EntityContext.Stores",
        "AjaxListStore", "AssessReport",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            else
            {
                table = new DataTables(
             ((IObjectContextAdapter)new EntityContext()).ObjectContext,
             "store",
             new string[] { "s.StoreName", "s.Address", "s.Region.RegionName", "s.StoreID" },
             "FLATTEN(select value Users.StoresCharged from EntityContext.Users where Users.UserID = " + user.UserID + ") as s",
             "AjaxListStore", "AssessReport",
             new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            ViewBag.DataTable = table;
            return View();
        }

        public ActionResult AjaxListStore(jQueryDataTableParamModel param)
        {
            DataTables table;
            User user = (User)Session["CurrentUser"];
            user = db.Users.Find(user.UserID);
            if (db.Roles.Find(1).Users.Contains(user) || db.Roles.Find(6).Users.Contains(user))
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "Stores.StoreName", "Stores.Address", "Stores.Region.RegionName", "Stores.StoreID" },
        "EntityContext.Stores",
        "AjaxListStore", "AssessReport",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            else
            {
                table = new DataTables(
             ((IObjectContextAdapter)new EntityContext()).ObjectContext,
             "store",
             new string[] { "s.StoreName", "s.Address", "s.Region.RegionName", "s.StoreID" },
             "FLATTEN(select value Users.StoresCharged from EntityContext.Users where Users.UserID = " + user.UserID + ") as s",
             "AjaxListStore", "AssessReport",
             new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Display(int id)
        {
            Session["ViewStoreID"] = id;
            AssessReportTable.Where = "AssessReports.Store.StoreID = " + id.ToString();
            ViewBag.StoreName = db.Stores.Find(id).StoreName;
            ViewBag.DataTable = AssessReportTable;
            return View();
        }
        //
        // GET: /AccessReport/Create

        public ActionResult Create()
        {
                IEnumerable<SelectListItem> items = ((User)Session["CurrentUser"]).StoresCharged
                    .Select(c => new SelectListItem
                    {
                        Value = c.StoreID.ToString(),
                        Text = c.StoreName
                    });
                ViewBag.StoreID = items;    
            //获得销售点信息，传给视图
                ViewBag.AssessItems = db.AssessItems.ToList();
                return View();
        }

        //
        // POST: /AccessReport/Create

        [HttpPost]
        public ActionResult Create(AssessReport assessReport)
        {
            ViewBag.Grades = assessReport.Grade;
            try
            {
                if (ModelState.IsValid)
                {
                    db.AssessReports.Add(assessReport);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error occurred while Creating store, please check your information!" + e.Message);
            }
            return View();
        }

        //
        // GET: /AccessReport/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AccessReport/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AccessReport/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AccessReport/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
