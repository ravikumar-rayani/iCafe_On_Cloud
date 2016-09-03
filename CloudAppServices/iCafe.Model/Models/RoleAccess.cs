//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{        
    public partial class RoleAccess : BaseModel
    {
        public int RoleID { get; set; }
        public int FeatureID { get; set; }
        public bool WirtePermissions { get; set; }
    
        public virtual Feature Feature { get; set; }
        public virtual Role Role { get; set; }
    }
}
