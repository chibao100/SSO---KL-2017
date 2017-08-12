using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tour_SSO.Models.ViewModel
{
    public class OrderViewModel
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}