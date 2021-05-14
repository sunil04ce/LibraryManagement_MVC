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
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password should be minimum eight characters, at least one letter, one number and one special character")]
        public string Password { get; set; }

        [Required]        
        public Nullable<int> RoleId { get; set; }
    }
}