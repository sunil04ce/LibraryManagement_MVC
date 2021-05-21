using LibraryManagement_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using LibraryManagement_MVC.Services;

namespace LibraryManagement_MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index(int? page)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                IPagedList<User> users = db.Users.OrderBy(x => x.Id).ToList().ToPagedList(page ?? 1, AppSettings.PageSizeInList);
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