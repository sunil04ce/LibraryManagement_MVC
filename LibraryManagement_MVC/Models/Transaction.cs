//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public Nullable<int> BookId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Book tblBook { get; set; }
        public virtual User tblUser { get; set; }
    }
}