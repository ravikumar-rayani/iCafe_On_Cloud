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
    
    public partial class RoleFeatureAccess
    {
        public int RoleID { get; set; }
        public int FeatureID { get; set; }
        public bool WirtePermissions { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int AccountId { get; set; }
        public Nullable<int> BranchId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Role Role { get; set; }
    }
}
