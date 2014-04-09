using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using System.Data;
using SalesManagementSystem.ViewModels;
using System.Data.Entity.Infrastructure;

namespace SalesManagementSystem.Controllers
{
    /// <summary>
    /// 负责销售点的相关处理
    /// </summary>
    public class StoreController : Controller
    {
        private EntityContext db = new EntityContext();

        private DataTables table = new DataTables(
            ((IObjectContextAdapter)new EntityContext()).ObjectContext,
            "store",
            new string[] { "Stores.StoreName", "Stores.Address", "Stores.Region.RegionName", "Stores.StoreID" },
            "EntityContext.Stores",
            "AjaxHandler", "Store",
            new string[] { "销售点名", "详细地址", "所属片区", "操作" },
            new string[] { "10%", "33%", "10%", "60%" });

        private class StoreJson
        {
            public string name { get; set; }
            public string rid { get; set; }
            public int dpts { get; set; }
            public string region { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public string address { get; set; }
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            return Json(table.AjaxHandler(param), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxGetStore()
        {
            var storeList = new List<StoreJson>();
            var stores = db.Stores.ToList();
            foreach (var item in stores)
            {
                storeList.Add(new StoreJson() { dpts = item.StoreID, name = item.StoreName, address = item.Address, lat = item.Latitude, lng = item.Longitude, rid = "test" + item.Region.RegionID.ToString(), region = item.Region.RegionName });
            }
            return Json(storeList, JsonRequestBehavior.AllowGet);
        }


        // GET: /Store/
        /// <summary>
        /// 显示销售点目录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.DataTable = table;           //所有销售站点信息
            return View();
        }

        // GET: /Store/Details/5
        /// <summary>
        /// 显示销售点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            Store store = db.Stores.Find(id);
            ViewData["Inspectors"] = store.Inspectors.ToList();   //检查员
            ViewData["Employees"] = store.Employees.ToList();    //负责人
            return View(store);
        }

        // GET: /Store/Create
        /// <summary>
        /// 增加销售点
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            SelectList regions = new SelectList(db.Regions.ToList(), "RegionID", "RegionName", db.Regions.ToList()[0]);    //获得销售片区信息，传给视图
            ViewBag.RegionID = regions;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Stores.Add(store);
                    db.SaveChanges();
                    return Redirect("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error occurred while Creating store, please check your information!" + e.Message);
            } 
            //用户创建失败，提醒用户，并请求重新输入信息
            SelectList regions = new SelectList(db.Regions.ToList(), "RegionID", "RegionName", db.Regions.ToList()[0]);           
            ViewBag.RegionID = regions;
            return View(store);
        }

        // GET: /Store/Edit/5
        /// <summary>
        /// 修改销售点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                SelectList regions = new SelectList(db.Regions.ToList(), "RegionID", "RegionName", store.Region.RegionID);              //取得片区信息，传给视图
                ViewBag.RegionID = regions;
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(store).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error occurred while Modifying store, please check your information!");
            } 
            //用户更新失败，提醒用户，并请求重新修改
            SelectList regions = new SelectList(db.Regions.ToList(), "RegionID", "RegionName", store.Region.RegionID);         
            ViewBag.RegionID = regions;
            return View(store);
        }

        // get: /Store/Delete/5
        /// <summary>
        /// 删除销售点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                Region region = db.Regions.Find(store.RegionID);
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Store store = db.Stores.Find(id);
                db.Stores.Remove(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "No such store exist!");
            }
            //用户删除销售点失败，重新返回到索引视图
            return RedirectToAction("Index");                            
        }

        ///get:/Store/AddInspectors/5
        /// <summary>
        /// 为销售点添加检查员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddInspectors(int? id)
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                List<User> storeUserList = store.Inspectors.ToList();    
                List<User> AllUser = db.Users.ToList();
                foreach (User u in storeUserList)
                {
                    if (AllUser.Contains(u))
                    {
                        AllUser.Remove(u);
                    }
                }
                //将销售点未添加的用户列表传给视图
                SelectList users = new SelectList(AllUser, "UserID", "UserName");
                ViewBag.User_UserID = users;
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddInspectors(int id, FormCollection form)
        {
            try
            {
                //添加检查员
                int InspectorID;
                int.TryParse(Request.Form["User_UserID"], out InspectorID);
                Store store = db.Stores.Find(id);
                User Inspector = db.Users.Find(InspectorID);
                if (store.Inspectors == null)
                {
                    //如果用户存在，添加才有效
                    store.Inspectors = new List<User>();
                }
                store.Inspectors.Add(db.Users.Find(InspectorID));
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                //为方便销售点连续添加用户，提示检查员添加成功后，停留在AddInspectors视图
                ViewData["Statue"] = "Add user" + Inspector.UserName + " succeed!";
                List<User> storeUserList = store.Inspectors.ToList();
                List<User> AllUser = db.Users.ToList();
                foreach (User u in storeUserList)
                {
                    if (AllUser.Contains(u))
                    {
                        AllUser.Remove(u);
                    }
                }
                //返回未在销售点添加的用户给视图
                SelectList users = new SelectList(AllUser, "UserID", "UserName");
                ViewBag.User_UserID = users;
                return View(store);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Can't add user for current store.");
            }
            return RedirectToAction("Index");
        }

        ///get:/Store/AddEmployees/5
        /// <summary>
        /// 为销售点添加负责人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddEmployees(int? id)
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                List<User> storeUserList = store.Employees.ToList();
                List<User> AllUser = db.Users.ToList();
                foreach (User u in storeUserList)
                {
                    if (AllUser.Contains(u))
                    {
                        AllUser.Remove(u);
                    }
                }
                //返回未在该销售站点添加为负责人的用户回视图
                SelectList users = new SelectList(AllUser, "UserID", "UserName");
                ViewBag.User_UserID = users;
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddEmployees(int id, FormCollection form)
        {
            try
            {
                int EmployeeID;
                int.TryParse(Request.Form["User_UserID"], out EmployeeID);
                Store store = db.Stores.Find(id);
                User Employee = db.Users.Find(EmployeeID);
                if (store.Employees == null)
                {
                    store.Employees = new List<User>();
                }
                store.Employees.Add(db.Users.Find(EmployeeID));
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                //为方便销售点连续添加用户，提示检查员添加成功后，停留在AddEmployees视图
                ViewData["Statue"] = "Add user" + Employee.UserName + " succeed!";
                List<User> storeUserList = store.Employees.ToList();
                List<User> AllUser = db.Users.ToList();
                foreach (User u in storeUserList)
                {
                    if (AllUser.Contains(u))
                    {
                        AllUser.Remove(u);
                    }
                }
                SelectList users = new SelectList(AllUser, "UserID", "UserName");
                ViewBag.User_UserID = users;
                return View(store);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Can't add user for current store.");
            }
            return RedirectToAction("Index");
        }

        ///get:/Store/DropInspectors/5
        /// <summary>
        /// 删除检查员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DropInspectors(int? id) 
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                SelectList Inspectors = new SelectList(store.Inspectors.ToList(), "UserID", "UserName");
                if (Inspectors.Count() == 0) Inspectors = null;
                ViewBag.User_UserID = Inspectors;
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DropInspectors(int id, FormCollection form)
        {
            try
            {
                Store store = db.Stores.Find(id);
                int InspectorID;
                int.TryParse(Request.Form["User_UserID"], out InspectorID);  //获取要被删除的检查员的用户ID
                User Inspector = db.Users.Find(InspectorID);
                store.Inspectors.Remove(Inspector);
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                //方便连续删除检查员，提示删除成功后，停留DropInspectors视图，同时返回未被删除的Inspectors
                SelectList Inspectors = new SelectList(store.Inspectors.ToList(), "UserID", "UserName");
                if (Inspectors.Count() == 0) Inspectors = null;
                ViewBag.User_UserID = Inspectors;
                ViewData["Statue"] = "Drop Inspector" + Inspector.UserName + " succeed";
                return View(store);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Server Error.");
            }
            return RedirectToAction("Index");
        }

        ///get:/Store/DropEmployees/5
        /// <summary>
        /// 删除检查员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DropEmployees(int? id)
        {
            if (id.HasValue)
            {
                Store store = db.Stores.Find(id);
                SelectList Employees = new SelectList(store.Employees.ToList(), "UserID", "UserName");
                if (Employees.Count() == 0) Employees = null;
                ViewBag.User_UserID = Employees;
                return View(store);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DropEmployees(int id, FormCollection form)
        {
            try
            {
                Store store = db.Stores.Find(id);
                int EmployeeID;
                int.TryParse(Request.Form["User_UserID"], out EmployeeID);
                User Employee = db.Users.Find(EmployeeID);
                store.Employees.Remove(Employee);
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

                //方便连续删除检查员，提示删除成功后，停留DropEmployees视图，同时返回未被删除的Employees
                SelectList Employees = new SelectList(store.Employees.ToList(), "UserID", "UserName");
                if (Employees.Count() == 0) Employees = null;
                ViewBag.User_UserID = Employees;
                ViewData["Statue"] = "Drop Employee" + Employee.UserName + " succeed";
                return View(store);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Server Error.");
            }
            return RedirectToAction("Index");
        }
    }
}
