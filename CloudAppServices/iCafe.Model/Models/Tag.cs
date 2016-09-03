//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Tag : BaseModel
    {
        public Tag()
        {
            this.ItemTags = new HashSet<ItemTag>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<ItemTag> ItemTags { get; set; }
    }
}
