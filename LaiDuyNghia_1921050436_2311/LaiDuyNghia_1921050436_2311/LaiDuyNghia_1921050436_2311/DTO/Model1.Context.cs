﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaiDuyNghia_1921050436_2311.DTO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLTHUVIEN1Entities : DbContext
    {
        public QLTHUVIEN1Entities()
            : base("name=QLTHUVIEN1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANGCAP> BANGCAPs { get; set; }
        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }
        public virtual DbSet<PHIEUTHUTIEN> PHIEUTHUTIENs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
