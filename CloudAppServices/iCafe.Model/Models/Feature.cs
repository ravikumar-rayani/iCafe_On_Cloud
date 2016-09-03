//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Feature : BaseModel
    {
        public Feature()
        {
            this.RoleAccesses = new HashSet<RoleAccess>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<RoleAccess> RoleAccesses { get; set; }
    }
}
