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
    public class AssessItemController : Controller
    {

        private EntityContext db = new EntityContext();
        private DataTables table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "条目项",
        new string[] { "AssessItems.ItemName", "AssessItems.Score", "AssessItems.Description", "AssessItems.AssessItemID" },
        "EntityContext.AssessItems",
        "AjaxHandler", "AssessItem",
        new string[] { "评分项名称", "总分", "评分项描述","操作"},
        new string[] { "20%", "10%", "55%", "20%" });

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /AccessItem/

        public ActionResult Index()
        {
            ViewBag.DataTable = table;
            return View();
        }

        //
        // GET: /AccessItem/Details/5

        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            AssessItem item = db.AssessItems.Find(id);
            return View(item);
        }

        //
        // GET: /AccessItem/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AccessItem/Create

        [HttpPost]
        public ActionResult Create(AssessItem model)
        {
            if (ModelState.IsValid) {
                db.AssessItems.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        //
        // GET: /AccessItem/Edit/5
 
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            AssessItem item = db.AssessItems.Find(id);
            if (item == null)
                return RedirectToAction("Index");
            return View(item);
        }

        //
        // POST: /AccessItem/Edit/5

        [HttpPost]
        public ActionResult Edit(AssessItem model)
        {
            try
            {
                AssessItem item = db.AssessItems.Find(model.AssessItemID);
                UpdateModel(item);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.AssessItemID });
            }
            catch
            {
                ModelState.AddModelError("", "修改错误！");
                return View();
            }
        }

        //
        // GET: /AccessItem/Delete/5
 
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            AssessItem assessItem = db.AssessItems.Find(id);
            if (assessItem == null) return RedirectToAction("Index");
            return View(assessItem);  
        }

        //
        // POST: /AccessItem/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                AssessItem item = db.AssessItems.Find(id);
                db.AssessItems.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
