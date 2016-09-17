//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            this.Items = new HashSet<Item>();
            this.ItemCategoriesAvailablities = new HashSet<ItemCategoriesAvailablity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemCategoriesAvailablity> ItemCategoriesAvailablities { get; set; }
    }
}
