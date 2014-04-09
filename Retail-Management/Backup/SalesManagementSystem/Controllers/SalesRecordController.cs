using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using SalesManagementSystem.ViewModels;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Common;

namespace SalesManagementSystem.Controllers
{

    public class GraphNode
    {
        public DateTime Date;
        public int Volume;
    }
    public class SalesRecordController : Controller
    {
        //
        // GET: /SalesRecord/
        EntityContext db = new EntityContext();


        private DataTables RecordTable = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "SalesRecord",
            new string[] { "SqlServer.DATENAME('dd' ,SalesRecords.Date) + '/' + SqlServer.DATENAME('mm' ,SalesRecords.Date) + '/' + SqlServer.DATENAME('yyyy' ,SalesRecords.Date)", "SalesRecords.Volume", "SalesRecords.Commodity.CommodityName", "SqlServer.DATENAME('yyyy' ,SalesRecords.Date)", "SqlServer.DATENAME('mm' ,SalesRecords.Date)", "SqlServer.DATENAME('dd' ,SalesRecords.Date)" },
            "EntityContext.SalesRecords",
            "AjaxHandler", "SalesRecord",
            new string[] { "销售日期（日/月/年）", "销售量", "销售产品", "年", "月", "日" },
            new string[] { "30%", "15%", "40%", "5%", "5%", "5%" });

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            RecordTable.Where = "SalesRecords.Store.StoreID = " + Session["ViewStoreID"].ToString();
            return Json(RecordTable.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Display(int id)
        {
            ViewBag.UserID = id;
            Session["ViewStoreID"] = id;
            RecordTable.Where = "SalesRecords.Store.StoreID = " + id.ToString();
            ViewBag.StoreName = db.Stores.Find(id).StoreName;
            ViewBag.DataTable = RecordTable;
            return View();
        }

        public ActionResult Index()
        {
            DataTables table;
            User user = (User)Session["CurrentUser"];
            user = db.Users.Find(user.UserID);
            if (db.Roles.Find(1).Users.Contains(user) || db.Roles.Find(4).Users.Contains(user))
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "s.StoreName", "s.Address", "s.Region.RegionName", "s.StoreID" },
        "FLATTEN(select value Users.StoresBelonged from EntityContext.Users where Users.UserID = " + user.UserID + ") as s",
        "AjaxListStore", "SalesRecord",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" },
            new string[] { "20%", "45%", "15%", "20%" });
            }
            else
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "Stores.StoreName", "Stores.Address", "Stores.Region.RegionName", "Stores.StoreID" },
        "EntityContext.Stores",
        "AjaxListStore", "SalesRecord",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" },
            new string[] { "20%", "45%", "15%", "20%" });
            }
            ViewBag.DataTable = table;
            return View();
        }

        public ActionResult AjaxListStore(jQueryDataTableParamModel param)
        {
            DataTables table;
            User user = (User)Session["CurrentUser"];
            user = db.Users.Find(user.UserID);
            if (db.Roles.Find(1).Users.Contains(user) || db.Roles.Find(4).Users.Contains(user))
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "Stores.StoreName", "Stores.Address", "Stores.Region.RegionName", "Stores.StoreID" },
        "EntityContext.Stores",
        "AjaxListStore", "SalesRecord",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            else
            {
                table = new DataTables(
        ((IObjectContextAdapter)new EntityContext()).ObjectContext,
        "store",
        new string[] { "s.StoreName", "s.Address", "s.Region.RegionName", "s.StoreID" },
        "FLATTEN(select value Users.StoresBelonged from EntityContext.Users where Users.UserID = " + user.UserID + ") as s",
        "AjaxListStore", "SalesRecord",
        new string[] { "销售点名", "详细地址", "所属片区", "操作" });
            }
            ViewBag.DataTable = table;
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /SalesRecord/Create

        public ActionResult Create()
        {
            List<Category> categoriesList = db.Categories.ToList();
            SelectList categories = new SelectList(categoriesList, "CategoryID", "CategoryName");
            ViewBag.CategoryID = categories;
            IEnumerable<SelectListItem> items = ((User)Session["CurrentUser"]).StoresBelonged
                .Select(c => new SelectListItem
                {
                    Value = c.StoreID.ToString(),
                    Text = c.StoreName
                });
            ViewBag.StoreID = items;
            return View();
        }

        //
        // POST: /SalesRecord/Create

        [HttpPost]
        public ActionResult Create(SalesRecord saleRecord)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SalesRecords.Add(saleRecord);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error occurred while Creating store, please check your information!" + e.Message);
            }
            
            SelectList Commodities = new SelectList(db.Commodities.ToList(), "CommodityID", "CommodityName", db.Commodities.ToList()[0]);   
            ViewBag.CommodityID = Commodities;
            SelectList stores = new SelectList(db.Stores.ToList(), "StoreID", "StoreName", db.Stores.ToList()[0]);    
            ViewBag.StoreID = stores;
            return View(saleRecord);
        }

        public ActionResult Analyse(int id)
        {
            ViewBag.AnalyseID = id;
            return View();
        }

        [HttpPost]
        public ActionResult Analyse(FormCollection collection)
        {
            Session["AnalyseID"] = Request.Form["AnalyseID"];
            Session["StartDate"] = Request.Form["StartDate"];
            Session["EndDate"] = Request.Form["EndDate"];
            return RedirectToAction("Graph");
        }


        public ActionResult Graph()
        {

            int storeID = Convert.ToInt32(Session["AnalyseID"]);
            var objContext = ((IObjectContextAdapter)db).ObjectContext;

            var dataList = new List<List<GraphNode>>();
            var nameList = new List<string>();
            foreach (var item in db.Categories.ToList())
            {
                nameList.Add(item.CategoryName);
                var list = new List<GraphNode>();
                var query = objContext.CreateQuery<DbDataRecord>("select Sum(S.Volume), S.Date from EntityContext.SalesRecords as S where S.StoreID = " + storeID.ToString() + " and S.Commodity.Category.CategoryID = " + item.CategoryID.ToString() + " and S.Date >= cast('" + Session["StartDate"].ToString() + "' as System.Datetime) and S.Date <= cast('" + Session["EndDate"].ToString() + "' as System.Datetime) group by S.Date, S.Commodity.Category");
                foreach (var subitem in query)
                {
                    list.Add(new GraphNode() { Volume = Convert.ToInt32(subitem[0]), Date = Convert.ToDateTime(subitem[1]) });
                }
                dataList.Add(list);
            }
            ViewBag.DataList = dataList;
            ViewBag.NameList = nameList;
            return View();
        }
    }
}
