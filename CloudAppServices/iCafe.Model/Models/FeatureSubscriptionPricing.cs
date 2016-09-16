using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class FeatureSubscriptionPricing
    {
        public int FeatureId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modified { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
