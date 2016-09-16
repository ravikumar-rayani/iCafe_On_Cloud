//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Feature
    {
        public Feature()
        {
            this.AccountTypeFeatures = new HashSet<AccountTypeFeatures>();
            this.RoleFeatureAccesses = new HashSet<RoleFeatureAccess>();
            this.FeatureSubscriptionPricings = new HashSet<FeatureSubscriptionPricing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<AccountTypeFeatures> AccountTypeFeatures { get; set; }
        public virtual ICollection<RoleFeatureAccess> RoleFeatureAccesses { get; set; }
        public virtual ICollection<FeatureSubscriptionPricing> FeatureSubscriptionPricings { get; set; }
    }
}
