//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Item : BaseModel
    {
        public Item()
        {
            this.ItemTags = new HashSet<ItemTag>();
            this.SubOrderDetails = new HashSet<SubOrderDetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public string ImagePath { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Price { get; set; }
        public List<int> TagIds { get; set; }
        public string SpicyLevel { get; set; }
        public string Ingrediants { get; set; }
        public string Description { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<ItemTag> ItemTags { get; set; }
        public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
    }
}
