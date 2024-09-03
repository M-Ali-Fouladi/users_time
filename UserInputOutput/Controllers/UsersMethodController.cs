using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInputOutput.Models;


namespace UserInputOutput.Controllers
{
    public class UsersMethodController : Controller
    {
        private UserDbSet db = new UserDbSet();

        //
        // GET: /UsersMethod/

        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Group).Include(u => u.UserType);
            return View(users.ToList());
        }
        #region LoginUser
        //--------------------------Login User-------GET-------------------------------------
        // get
        public ActionResult LoginUser()
        {
            return View();
        }

        //------------------------Login user---------POST-------------
        [HttpPost]
        public ActionResult LoginUser(string UserName, string Password)
        {
            //var Un = from u in db.Users
            //                   where u.UserName == UserName 
            //                   select u;
            var Un = db.Users.Where(q => q.UserName == UserName);

            if (Un.ToList().Count == 0 || UserName=="")
            {
                ViewBag.message = "Your userName Doesnt Exists in DataBase";
            
            }
            else
            {
                //var Ps = from p in Un
                //         where p.Password == Password
                //         select p;
                var Ps = Un.Where(q => q.Password == Password);

                if (Ps.ToList().Count == 0 || Password == "")
                {
                    ViewBag.message = "Your Password Doesnt Exists in DataBase";

                }
                else
                {
                    var u = Ps.FirstOrDefault();
                    u.LastLogin = DateTime.Now;
                    db.SaveChanges();
                    Session["User"] = u;
                    return RedirectToAction("FirstPage");
                }
            }
            
            return View();

        }

        #endregion
        #region FirstPage

        public ActionResult FirstPage()
        {
            return View();
        }
        #endregion

        // GET: /UsersMethod/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /UsersMethod/Create

        public ActionResult Create()
        {

            ViewBag.UserGroupId = new SelectList(db.UserGroups, "UserGroupId", "Name");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name");
            return View();
        }

        //
        // POST: /UsersMethod/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                //---------------------------------seting default value --------------- 
                user.UserGroupId = 1;
                user.UserTypeId = 1;
                db.Users.Add(user);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserGroupId = new SelectList(db.UserGroups, "UserGroupId", "Name", user.UserGroupId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
            return View(user);
        }

        //
        // GET: /UsersMethod/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "UserGroupId", "Name", user.UserGroupId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
            return View(user);
        }

        //
        // POST: /UsersMethod/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserGroupId = new SelectList(db.UserGroups, "UserGroupId", "Name", user.UserGroupId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "Name", user.UserTypeId);
            return View(user);
        }

        //
        // GET: /UsersMethod/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /UsersMethod/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}