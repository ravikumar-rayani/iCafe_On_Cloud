using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class Branch
    {
        public Branch()
        {
            this.Devices = new HashSet<Device>();
            this.ItemCategoriesAvailablities = new HashSet<ItemCategoriesAvailablity>();
            this.ItemsAvailablities = new HashSet<ItemsAvailablity>();
            this.Orders = new HashSet<Order>();
            this.Tables = new HashSet<Table>();
            this.TagsAvailablities = new HashSet<TagsAvailablity>();
            this.Users = new HashSet<User>();
            this.WaiterTables = new HashSet<WaiterTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<ItemCategoriesAvailablity> ItemCategoriesAvailablities { get; set; }
        public virtual ICollection<ItemsAvailablity> ItemsAvailablities { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<TagsAvailablity> TagsAvailablities { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<WaiterTable> WaiterTables { get; set; }
    }
}
