using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInputOutput.Models;

namespace UserInputOutput.Controllers
{
    
    public class HomeController : Controller
    {
        public UserDbSet db = new UserDbSet();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.id = "";
            return View();
       
        }
       
        [HttpPost]
        public ActionResult Index(string id)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.id = id;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
    }
}
