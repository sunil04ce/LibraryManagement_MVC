using LibraryManagement_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(ModelState.IsValid)
            {
                using(LibraryManagementContext db = new LibraryManagementContext())
                {
                    var obj = db.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
                    if(obj != null)
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
            }

            return View(user);
        }
    }
}