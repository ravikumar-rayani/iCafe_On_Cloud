//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{    
    public partial class Role
    {
        public Role()
        {
            this.RoleFeatureAccesses = new HashSet<RoleFeatureAccess>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
    
        public virtual ICollection<RoleFeatureAccess> RoleFeatureAccesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
