using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInputOutput.Models;

namespace UserInputOutput.Controllers
{
    
    public class UsersController : Controller
    {
        public UserDbSet db = new UserDbSet();


        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
            
        }

        //
        // GET: /Users/Details/5

       public ActionResult LoginUser(string UserName,string Password)
        {
           ViewBag.message = "Login";
            User u = db.Users.Find(UserName);
            User p = db.Users.Find(Password); 
           if (u == null)
            {
                ViewBag.message = "Your userName Doesnt Exists in DataBase";
            }
            if (p == null)
            {
                ViewBag.message = "Your Password Doesnt Exists in DataBase";
            }

            return View();

        }
        //=============== Create User Methods=========================================
       //Get
        public ActionResult Create()
       {
           return View();
       }

       //
       // POST: /Student/Create

       [HttpPost]
       public ActionResult Create(User User)
       {
           if (ModelState.IsValid)
           {
               db.Users.Add(User);
               db.SaveChanges();
               return RedirectToAction("FirstPage");
           }

           return View(User);
       }
        //=======================================================
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

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
        // GET: /Users/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

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
