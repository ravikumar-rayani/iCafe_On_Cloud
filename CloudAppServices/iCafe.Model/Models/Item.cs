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
            this.SubOrderDetails = new HashSet<SubOrderDetail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Price { get; set; }
        public int SpicyLevel { get; set; }
        public string Ingrediants { get; set; }
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string FullImage { get; set; }

        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
    }
}
