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
    
    public partial class ItemCategoryTag
    {
        public int ItemCategoryID { get; set; }
        public int TagID { get; set; }
        public int AccountID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual Tag Tag { get; set; }
    }
}