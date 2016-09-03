//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class PaymentStatus : BaseModel
    {
        public PaymentStatus()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
