﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class movieEntities : DbContext
    {
        public movieEntities()
            : base("name=movieEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dienvien> dienviens { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<phim> phims { get; set; }
        public virtual DbSet<phim_dienvien> phim_dienvien { get; set; }
        public virtual DbSet<phim_quocgia> phim_quocgia { get; set; }
        public virtual DbSet<phim_theloaiphim> phim_theloaiphim { get; set; }
        public virtual DbSet<phimitem> phimitems { get; set; }
        public virtual DbSet<quocgia> quocgias { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<theloaiphim> theloaiphims { get; set; }
    }
}
