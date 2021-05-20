using LibraryManagement_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
            //if (Session["UserId"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
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
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "The email or password provided is incorrect.");
                }
            }
            //}

            return View(user);
        }
        
    }
}