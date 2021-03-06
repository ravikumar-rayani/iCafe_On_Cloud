//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iCafe.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeatureSubscriptionPricing
    {
        public int SubscriptionTypeId { get; set; }
        public int FeatureId { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual Feature Feature { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
