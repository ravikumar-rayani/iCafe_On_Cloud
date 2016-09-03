//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Role : BaseModel
    {
        public Role()
        {
            this.RoleAccesses = new HashSet<RoleAccess>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<RoleAccess> RoleAccesses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
