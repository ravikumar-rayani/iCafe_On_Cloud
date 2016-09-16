//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Phone { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}   
