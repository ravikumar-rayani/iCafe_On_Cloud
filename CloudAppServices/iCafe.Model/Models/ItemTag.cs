//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class ItemTag : BaseModel
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
