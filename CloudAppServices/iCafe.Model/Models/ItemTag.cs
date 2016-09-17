//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class ItemTag
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
        public int AccountId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual Account Account { get; set; }
        public virtual Item Item { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
