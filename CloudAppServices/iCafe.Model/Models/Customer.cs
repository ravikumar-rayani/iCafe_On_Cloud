//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{   
    public partial class Customer : BaseModel
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public Decimal Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
