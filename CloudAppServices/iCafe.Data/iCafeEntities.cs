using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using iCafe.Model.Models;
using iCafe.Data.Configuration;

namespace iCafe.Data
{
    public class iCafeEntities : DbContext
    {
        public iCafeEntities(string DataBase = "iCafeDB", String Schema = null)//CustomerName
            : base(string.Format(ConfigurationManager.ConnectionStrings["iCafeEntities"].ToString(), DataBase)) //base("iCafeEntities") 
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public iCafeEntities()
            : base("iCafeEntities") 
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        #region dbSets

        public DbSet<Feature> Features  { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<AccountTypeFeatures> AccountTypeFeatures { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<FeatureSubscriptionPricing> FeatureSubscriptionPricings { get; set; }
        public DbSet<AccountSubscriptionDetail> AccountSubscriptionDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ItemCategory> ItemCategories  { get; set; }        
        public DbSet<ItemCategoriesAvailablity> ItemCategoriesAvailablities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemsAvailablity> ItemsAvailablities { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsAvailablity> TagsAvailablities { get; set; }
        public DbSet<ItemTag> ItemTags  { get; set; }
        //public DbSet<Menu> Menus { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SubOrderDetail> SubOrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleFeatureAccess> RoleAccess { get; set; }
        public DbSet<WaiterTable> WaiterTables { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configuraing fields
            #region Configure fields
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new AccountSubscriptionDetailConfiguration());
            modelBuilder.Configurations.Add(new AccountTypeConfiguration());
            modelBuilder.Configurations.Add(new AccountTypeFeaturesConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new DeviceConfiguration());
            modelBuilder.Configurations.Add(new FeatureConfiguration());
            modelBuilder.Configurations.Add(new FeatureSubscriptionPricingConfiguration());
            modelBuilder.Configurations.Add(new ItemCategoriesAvailablityConfiguration());
            modelBuilder.Configurations.Add(new ItemCategoryConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ItemsAvailablityConfiguration());
            modelBuilder.Configurations.Add(new ItemTagConfiguration());
            //modelBuilder.Configurations.Add(new MenuConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new PaymentStatusConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleFeatureAccessConfiguration());
            modelBuilder.Configurations.Add(new SubOrderDetailConfiguration());
            modelBuilder.Configurations.Add(new SubscriptionTypeConfiguration());
            modelBuilder.Configurations.Add(new TableConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new TagsAvailablityConfiguration());
            modelBuilder.Configurations.Add(new WaiterTableConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            #endregion
        }
    }
}
