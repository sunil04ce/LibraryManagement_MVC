using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement_MVC.Models
{
    [MetadataType(typeof(BookMedata))]
    public partial class Book
    {
    }

    public class BookMedata
    {
        
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public Nullable<int> Copies { get; set; }

        [DisplayName("Publication Name")]
        public string PubName { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> Copyright { get; set; }

        [DisplayName("Added Date")]
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Status { get; set; }
    }

}