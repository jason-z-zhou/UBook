using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using SalesManagementSystem.ViewModels;
using System.Data.Entity.Infrastructure;

namespace SalesManagementSystem.Controllers
{
    public class RegionController : Controller
    {
        //
        // GET: /Region/
        private EntityContext db = new EntityContext();
        private DataTables table = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "region",
            new string[] { "Regions.RegionName", "ANYELEMENT(select count(0) as Size from Regions.Stores).Size", "Regions.Address", "Regions.RegionID" },
            "EntityContext.Regions",
            "AjaxHandler", "Region",
            new string[] { "片区名", "销售点数量", "地址", "操作" });

        private DataTables storeTable = new DataTables(
           ((IObjectContextAdapter)new EntityContext()).ObjectContext,
           "片区内商店列表",
           new string[] { "Stores.StoreID", "Stores.StoreName", "Stores.Address", "Stores.CreationTime", "Stores.Longitude", "Stores.Latitude", "Stores.Comment" },
           "EntityContext.Stores",
           "AjaxHandler1", "Region",
           new string[] { "销售点ID", "销售点名字", "详细地址", "创建时间", "经度", "纬度", "备注" },
           new string[] { "20%", "20%", "45%", "8%", "8%", "8%", "8%"});



        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            ViewBag.DataTable = table;
            return View();
        }

        //
        // GET: /Region/Details/5

        public ActionResult Details(int id)
        {
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        //
        // GET: /Region/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Region/Create

        [HttpPost]
        public ActionResult Create(Region model)
        {
            if (ModelState.IsValid)
            {
                db.Regions.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        //
        // GET: /Region/Edit/5
 
        public ActionResult Edit(int id)
        {
            Region region = db.Regions.Find(id);
            if (region == null)
                return RedirectToAction("Index");
            return View(region);
        }

        //
        // POST: /Region/Edit/5

        [HttpPost]
        public ActionResult Edit(Region model)
        {
            try
            {
                Region region = db.Regions.Find(model.RegionID);
                UpdateModel(region);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.RegionID });
            }
            catch
            {
                ModelState.AddModelError("", "修改错误！");
                return View();
            }
        }

        //
        // GET: /Region/Delete/5
 
        public ActionResult Delete(int id)
        {
            Region region = db.Regions.Find(id);
            if (region == null) return RedirectToAction("Index");
            return View(region); 
        }

        //
        // POST: /Region/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Region region = db.Regions.Find(id);
                db.Regions.Remove(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowStores(int id, FormCollection collection) {
           Session["ViewRegionID"] = id;
           storeTable.Where = "Stores.RegionID = " + id.ToString();
           ViewBag.RegionName = db.Regions.Find(id).RegionName;
           ViewBag.DataTable = storeTable;
           return View();
        }

        public ActionResult AjaxHandler1(jQueryDataTableParamModel param)
        {
            storeTable.Where = "Stores.RegionID = " + Session["ViewRegionID"].ToString();
            return Json(storeTable.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }
    }
}
