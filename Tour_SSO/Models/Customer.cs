//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tour_SSO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.DetailOfTourOrders = new HashSet<DetailOfTourOrder>();
            this.Members = new HashSet<Member>();
        }
    
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<int> PassportNumber { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<DetailOfTourOrder> DetailOfTourOrders { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
