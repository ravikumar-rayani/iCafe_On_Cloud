//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            this.SubOrderDetails = new HashSet<SubOrderDetail>();
        }
    
        public int SubOrderId { get; set; }
        public int OrderId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
    }
}
