using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class Account
    {
        public Account()
        {
            this.Branches = new HashSet<Branch>();
            this.RoleFeatureAccesses = new HashSet<RoleFeatureAccess>();
            this.AccountSubscriptionDetails = new HashSet<AccountSubscriptionDetail>();
            this.Customers = new HashSet<Customer>();
            this.Devices = new HashSet<Device>();
            this.ItemCategories = new HashSet<ItemCategory>();
            this.Items = new HashSet<Item>();
            this.ItemTags = new HashSet<ItemTag>();
            this.Orders = new HashSet<Order>();
            this.Tables = new HashSet<Table>();
            this.Tags = new HashSet<Tag>();
            this.Users = new HashSet<User>();
            this.WaiterTables = new HashSet<WaiterTable>();
            this.Users1 = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string EmailId { get; set; }
        public int AccoutTypeId { get; set; }
        public bool IsMultiBranchesAllowed { get; set; }
        public Nullable<int> MaxBranches { get; set; }
        public System.DateTime EndDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<RoleFeatureAccess> RoleFeatureAccesses { get; set; }
        public virtual ICollection<AccountSubscriptionDetail> AccountSubscriptionDetails { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<ItemCategory> ItemCategories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemTag> ItemTags { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WaiterTable> WaiterTables { get; set; }
        public virtual ICollection<User> Users1 { get; set; }
    }
}
