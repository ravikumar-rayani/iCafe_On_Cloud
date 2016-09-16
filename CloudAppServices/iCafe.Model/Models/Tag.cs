//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Tag
    {
        public Tag()
        {
            this.ItemTags = new HashSet<ItemTag>();
            this.TagsAvailablities = new HashSet<TagsAvailablity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<ItemTag> ItemTags { get; set; }
        public virtual ICollection<TagsAvailablity> TagsAvailablities { get; set; }
    }
}
