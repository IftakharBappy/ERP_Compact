﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_Compact.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ERPMgtEntities : DbContext
    {
        public ERPMgtEntities()
            : base("name=ERPMgtEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aisle> Aisle { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssetCategory> AssetCategory { get; set; }
        public virtual DbSet<AssetSubcategory> AssetSubcategory { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<ImageFile> ImageFile { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<ItemSubcategory> ItemSubcategory { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<ProductionProcessSetup> ProductionProcessSetup { get; set; }
        public virtual DbSet<Row_Store> Row_Store { get; set; }
        public virtual DbSet<Shelf> Shelf { get; set; }
        public virtual DbSet<SubModule> SubModule { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Upazilla> Upazilla { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Usergroup> Usergroup { get; set; }
        public virtual DbSet<UsergroupToForm> UsergroupToForm { get; set; }
        public virtual DbSet<UsergroupToModule> UsergroupToModule { get; set; }
        public virtual DbSet<UsergroupToSubmodule> UsergroupToSubmodule { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
    }
}
