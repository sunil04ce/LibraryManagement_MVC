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
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password should be minimum eight characters, at least one letter, one number and one special character.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Confirm password is required.")]
        //[Compare("Password", ErrorMessage ="Passwords do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "RoleId is required.")]        
        public Nullable<int> RoleId { get; set; }
    }
}