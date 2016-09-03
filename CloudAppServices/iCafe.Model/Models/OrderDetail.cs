//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class OrderDetail : BaseModel
    {
        public OrderDetail()
        {
            this.SubOrderDetails = new HashSet<SubOrderDetail>();
        }
    
        public int SubOrderId { get; set; }
        public int OrderId { get; set; }
    
        public virtual ICollection<SubOrderDetail> SubOrderDetails { get; set; }
        public virtual Order Order { get; set; }
    }
}
