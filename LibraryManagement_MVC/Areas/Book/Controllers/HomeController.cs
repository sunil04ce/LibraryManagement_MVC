using LibraryManagement_MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using LibraryManagement_MVC.Services;

namespace LibraryManagement_MVC.Areas.Book.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Book/Home
        public ActionResult Index(int? page)
        {
            using(LibraryManagementContext db = new LibraryManagementContext())
            {
                IPagedList<Models.Book> books = db.Books.OrderBy(x => x.Id).ToList().ToPagedList(page ?? 1, AppSettings.PageSizeInList);
                return View(books);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Book book)
        {
            using(LibraryManagementContext db = new LibraryManagementContext())
            {
                if(ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using(LibraryManagementContext db = new LibraryManagementContext())
            {
                Models.Book book = db.Books.Where(x => x.Id == id).FirstOrDefault();
                return View(book);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Book book)
        {
            if(ModelState.IsValid)
            {
                using (LibraryManagementContext db = new LibraryManagementContext())
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        public ActionResult Details(int? id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Models.Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
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

                Models.Book book = db.Books.Find(id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                return View(book);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            using (LibraryManagementContext db = new LibraryManagementContext())
            {
                Models.Book book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}