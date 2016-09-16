using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            this.AccountSubscriptionDetails = new HashSet<AccountSubscriptionDetail>();
            this.FeatureSubscriptionPricings = new HashSet<FeatureSubscriptionPricing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DurationInDays { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<AccountSubscriptionDetail> AccountSubscriptionDetails { get; set; }
        public virtual ICollection<FeatureSubscriptionPricing> FeatureSubscriptionPricings { get; set; }
    }
}
