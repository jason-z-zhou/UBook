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
        /// 用于处理产品分类信息
        /// </summary>
    public class CategoryController : Controller
    {
       
        private EntityContext db = new EntityContext();

        private DataTables table = new DataTables(
           ((IObjectContextAdapter)new EntityContext()).ObjectContext,
           "test",
           new string[] { "Categories.CategoryName", "Categories.Description", "ANYELEMENT(select count(0) as Size from Categories.Commodities).Size", "Categories.CategoryID" },
           "EntityContext.Categories",
           "AjaxHandler", "Category",
           new string[] { "商品类型名", "描述", "商品总数", "操作" },
           new string[] { "15%", "45%", "15%", "25%" });

        private DataTables CommodityTable = new DataTables(
          ((IObjectContextAdapter)new EntityContext()).ObjectContext,
          "该种类的商品列表",
         new string[] { "Commodities.CommodityName", "Commodities.Price", "Commodities.Description","Commodities.CommodityID" },
            "EntityContext.Commodities",
            "AjaxHandler1", "Category",
            new string[] { "商品名", "单价", "描述", "操作" },
           new string[] { "35%", "10%", "40%", "20%" });


        private class CommodityOption
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxGetCommodity(int? CategoryID)
        {
            var commodityList = new List<CommodityOption>();
            if (CategoryID != null)
            {
                var commodities = db.Categories.Find(CategoryID).Commodities;
                foreach (var item in commodities)
                {
                    commodityList.Add(new CommodityOption() { id = item.CommodityID.ToString(), name = item.CommodityName });
                }
            }
            return Json(commodityList, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 显示分类目录
        /// GET: /Category/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.DataTable = table;
            return View(); 
        }

        /// <summary>
        /// 显示分类细节
        // GET: /Category/Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        

        /// <summary>
        /// 创建新的产品类型
        /// GET: /Category/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        } 


        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }     
            return View();
        }
        
        //
        // GET: /Category/Edit/5
        /// <summary>
        /// 编辑产品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Category Category = db.Categories.Find(id);
            ViewBag.Commodities = db.Commodities.OrderBy(g => g.CommodityName).ToList();
            return View(Category);
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            Category Category = db.Categories.Find(model.CategoryID);


            if (TryUpdateModel(Category))
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Commodities = db.Commodities.OrderBy(g => g.CommodityName).ToList();
                return View(Category);


            }
        }

        //
        // GET: /Category/Delete/5
        /// <summary>
        /// 删除产品分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null) return RedirectToAction("Index");
            return View(category);  
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Category category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowCommodities(int id, FormCollection collection)
        {
            Session["ViewCategoryID"] = id;
            CommodityTable.Where = "Commodities.CategoryID = " + id.ToString();
            ViewBag.CategoryName = db.Categories.Find(id).CategoryName;
            ViewBag.DataTable = CommodityTable;
            return View();
        }

        public ActionResult AjaxHandler1(jQueryDataTableParamModel param)
        {
            CommodityTable.Where = "Commodities.CategoryID = " + Session["ViewCategoryID"].ToString();
            return Json(CommodityTable.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }




    }
}
