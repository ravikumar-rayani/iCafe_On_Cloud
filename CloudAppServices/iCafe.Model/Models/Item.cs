//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Item
    {
        public Item()
        {
            this.ItemTags = new HashSet<ItemTag>();
            this.SubOrderDetails = new HashSet<SubOrderDetail>();
            this.ItemsAvailablities = new HashSet<ItemsAvailablity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public decimal Price { get; set; }
        public int SpicyLevel { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Ingrediants { get; set; }
        public string Description { get; set; }
        public string SmallImageUrl { get; set; }
        public string FullImageUrl { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<ItemTag> ItemTags { get; set; }
        public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
        public virtual ICollection<ItemsAvailablity> ItemsAvailablities { get; set; }
    }
}
