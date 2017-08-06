﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TourEntities : DbContext
    {
        public TourEntities()
            : base("name=TourEntities")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Area> Areas { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailOfTourOrder> DetailOfTourOrders { get; set; }
        public DbSet<ForeignArea> ForeignAreas { get; set; }
        public DbSet<Gallary> Gallaries { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDetail> TourDetails { get; set; }
        public DbSet<TourGallary> TourGallaries { get; set; }
        public DbSet<TourOrder> TourOrders { get; set; }
        public DbSet<TourPlace> TourPlaces { get; set; }
        public DbSet<TourPlaceGallary> TourPlaceGallaries { get; set; }
    }
}
