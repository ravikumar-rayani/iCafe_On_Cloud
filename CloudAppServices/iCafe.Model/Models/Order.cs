//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{

    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<int> PaymentStatusId { get; set; }
        public Nullable<int> RatingOnFood { get; set; }
        public Nullable<int> RatingOnService { get; set; }
        public string Feedback { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public int AccountId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int BranchId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
