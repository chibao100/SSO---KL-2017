//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Movie.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class phimitem
    {
        public int id { get; set; }
        public int idphim { get; set; }
        public int tap { get; set; }
        public string link { get; set; }
        public string tentapphim { get; set; }
        public string linkdowload { get; set; }
    
        public virtual phim phim { get; set; }
    }
}
