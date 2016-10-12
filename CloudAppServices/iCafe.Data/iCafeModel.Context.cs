﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iCafe.Entity
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class iCafeEntities : DbContext
    {
        public iCafeEntities()
            : base("name=iCafeEntities")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public iCafeEntities(string DataBase = "iCafeDB", String Schema = null)//CustomerName
            : base(string.Format(ConfigurationManager.ConnectionStrings["iCafeEntities"].ToString(), DataBase)) //base("iCafeEntities") 
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountSubscriptionDetail> AccountSubscriptionDetails { get; set; }
        public virtual DbSet<AccountTypeFeature> AccountTypeFeatures { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FeatureSubscriptionPricing> FeatureSubscriptionPricings { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemCategoriesAvailablity> ItemCategoriesAvailablities { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemsAvailablity> ItemsAvailablities { get; set; }
        public virtual DbSet<ItemTag> ItemTags { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<PaymentStatu> PaymentStatus { get; set; }
        public virtual DbSet<RoleAccess> RoleAccesses { get; set; }
        public virtual DbSet<RoleFeatureAccess> RoleFeatureAccesses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubOrderDetail> SubOrderDetails { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagsAvailablity> TagsAvailablities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WaiterTable> WaiterTables { get; set; }
        public virtual DbSet<ItemCategoryTag> ItemCategoryTags { get; set; }
    }
}
