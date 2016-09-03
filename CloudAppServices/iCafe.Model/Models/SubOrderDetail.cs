//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class SubOrderDetail : BaseModel
    {
        public int SubOrderId { get; set; }
        public int ItemId { get; set; }
        public Nullable<int> OrderQuantiry { get; set; }
        public string OrderType { get; set; }
        public string OrderPreferences { get; set; }
    
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Item Item { get; set; }
    }
}
