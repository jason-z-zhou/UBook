using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;

namespace SalesManagementSystem.Controllers
{
    /// <summary>
    /// 用于站内信的发布
    /// </summary>
    public class MessageController : Controller
    {
        //发信
        public ActionResult Send(Message model) 
        {
            return View();
        }

        //写信
        public ActionResult Write(Message model)
        {
            return View();
        }

        //读信
        public ActionResult Read()
        {
            return View();
        }

        //收件箱
        public ActionResult Inbox()
        {
            return View();
        }

        //发件箱
        public ActionResult Outbox()
        {
            return View();
        }
        
    }
}
