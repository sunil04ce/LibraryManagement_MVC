using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement_MVC.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        
    }

    public class UserMetadata
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}