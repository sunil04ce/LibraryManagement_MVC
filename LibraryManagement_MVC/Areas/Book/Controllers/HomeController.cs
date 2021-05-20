using LibraryManagement_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagement_MVC.Areas.Book.Controllers
{
    public class HomeController : Controller
    {
        // GET: Book/Home
        public ActionResult Index()
        {
            using(LibraryManagementContext db = new LibraryManagementContext())
            {
                IEnumerable<Models.Book> books = db.Books.OrderBy(x => x.Id).ToList();
                return View(books);
            }
        }
    }
}