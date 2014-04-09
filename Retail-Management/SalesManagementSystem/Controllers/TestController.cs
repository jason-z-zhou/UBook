using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Controllers
{
    public class TestController : Controller
    {
        private EntityContext db = new EntityContext();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            db.AllowRules.Add(new AllowRule { Path = "Test/Help" });
            db.AllowRules.Add(new AllowRule { Path = "Test/Help1" });
            db.AllowRules.Add(new AllowRule { Path = "Test/Help2" });
            return View(db.AllowRules.ToList());
        }

    }
}
