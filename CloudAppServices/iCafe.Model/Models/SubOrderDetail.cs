//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{

    public partial class SubOrderDetail
    {
        public int SubOrderId { get; set; }
        public int ItemId { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderType { get; set; }
        public string OrderPreferences { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }

        public virtual Item Item { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
