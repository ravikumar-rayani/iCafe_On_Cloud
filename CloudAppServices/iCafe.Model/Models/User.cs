//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class User : BaseModel
    {
        public User()
        {
            //this.Customers = new HashSet<Customer>();
            //this.Devices = new HashSet<Device>();
            //this.Features = new HashSet<Feature>();
            //this.ItemTags = new HashSet<ItemTag>();
            //this.Orders = new HashSet<Order>();
            //this.OrderDetails = new HashSet<OrderDetail>();
            //this.SubOrderDetails = new HashSet<SubOrderDetail>();
            //this.RoleAccess = new HashSet<RoleAccess>();
            //this.Tables = new HashSet<Table>();
            //this.Tags = new HashSet<Tag>();
            //this.ItemCategories = new HashSet<ItemCategory>();
            //this.Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }


        //public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<Device> Devices { get; set; }
        //public virtual ICollection<Feature> Features { get; set; }
        //public virtual ICollection<ItemTag> ItemTags { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //public virtual ICollection<PaymentStatus> Payment { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
        //public virtual ICollection<RoleAccess> RoleAccess { get; set; }
        //public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
        //public virtual ICollection<Table> Tables { get; set; }
        //public virtual ICollection<Tag> Tags { get; set; }
        //public virtual ICollection<ItemCategory> ItemCategories { get; set; }
        //public virtual ICollection<Item> Items { get; set; }
        //public virtual ICollection<User> Users { get; set; }
        public virtual Role Role { get; set; }
    }
}
