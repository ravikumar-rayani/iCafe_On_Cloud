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
    
    public partial class TagsAvailablity
    {
        public int TagId { get; set; }
        public int BranchId { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
