//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class ItemCategory : BaseModel
    {
        public ItemCategory()
        {
            this.Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
