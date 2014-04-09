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
    /// <summary>
    /// 用于对商品的操作
    /// </summary>
    public class CommodityController : Controller
    {
        private EntityContext db = new EntityContext();

        private DataTables table = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "test",
            new string[] { "Commodities.CommodityName", "Commodities.Price", "Commodities.Description", "Commodities.Category.CategoryName", "Commodities.CommodityID" },
            "EntityContext.Commodities",
            "AjaxHandler", "Commodity",
            new string[] { "商品名", "单价", "描述", "所属商品类型", "操作" },
            new string[] { "20%", "10%", "30%", "15%", "25%" });

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }



        // GET: /Good/
        /// <summary>
        /// 显示商品目录
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            ViewBag.DataTable = table;
            return View();//所有商品信息
        }

        // GET: /Good/Details/5
        /// <summary>
        /// 显示商品细节
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public ViewResult Details(int id)
        {
            Commodity commodidy = db.Commodities.Find(id);
            return View(commodidy);
        }


        //  GET: /Category/Create
        /// <summary>
        /// 增加商品
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SelectList categories = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName", db.Categories.ToList()[0]);    //获得商品种类信息，传给视图
            ViewBag.CategoryID = categories;
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Commodity model)
        {
            if (ModelState.IsValid)
            {
                db.Commodities.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList categories = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName", db.Categories.ToList()[0]);//获得商品种类信息，传给视图    
            ViewBag.CategoryID = categories;
            return View(model);

        }


        // GET: /Category/Edit/5
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Commodity commodity = db.Commodities.Find(id);
                SelectList categories = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName", commodity.CategoryID);   //获得商品种类信息，传给视图
                ViewBag.CategoryID = categories;
                return View(commodity);

            }
            return RedirectToAction("Index");
        }

        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Commodity model)
        {
            try
            {
                Commodity commodity = db.Commodities.Find(model.CommodityID);
                UpdateModel(commodity);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = model.CommodityID });

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "修改错误！");

            }
            SelectList categories = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName", db.Categories.ToList()[0]);    //获得商品种类信息，传给视图
            ViewBag.CategoryID = categories;
            return View(model);
        }
        // GET: /Category/Delete/5
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Commodity commodity = db.Commodities.Find(id);
            if (commodity == null)
            {
                return RedirectToAction("Index");
            }

            return View(commodity);
        }

        // POST: /Category/Delete/5
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Commodity commodity = db.Commodities.Find(id);
                db.Commodities.Remove(commodity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
