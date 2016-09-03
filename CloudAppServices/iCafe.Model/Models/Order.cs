//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Order : BaseModel
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public string PaymentStatus { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice  { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
