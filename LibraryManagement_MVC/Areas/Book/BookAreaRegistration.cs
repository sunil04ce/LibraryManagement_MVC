using System.Web.Mvc;

namespace LibraryManagement_MVC.Areas.Book
{
    public class BookAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Book";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Book_default",
                "Book/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}