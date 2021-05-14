using LibraryManagement_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement_MVC.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            //if (ModelState.IsValid)
            //{
                using (LibraryManagementContext db = new LibraryManagementContext())
                {
                    var obj = db.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["UserName"] = obj.Name.ToString();
                        //Session["UserEmail"] = obj.Email;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The email or password provided is incorrect.");
                    }
                }
            //}

            return View(user);
        }

        public ActionResult Index()
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                IEnumerable<User> users = db.Users.OrderBy(x => x.Id).ToList();
                return View(users);
            }
        }
        
        public ActionResult Create()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                if(ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
        }

        public ActionResult Edit(int id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                User user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                using (LibraryManagementContext db = new LibraryManagementContext())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
        }

        public ActionResult Delete(int? id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}