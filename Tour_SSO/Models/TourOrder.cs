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
    
    public partial class TourOrder
    {
        public TourOrder()
        {
            this.DetailOfTourOrders = new HashSet<DetailOfTourOrder>();
        }
    
        public int TourOrderId { get; set; }
        public Nullable<int> TourId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> NumberOfSeat { get; set; }
        public Nullable<double> PriceSum { get; set; }
        public string UnitPriceSum { get; set; }
        public Nullable<double> PaidPrice { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual ICollection<DetailOfTourOrder> DetailOfTourOrders { get; set; }
        public virtual Tour Tour { get; set; }
    }
}