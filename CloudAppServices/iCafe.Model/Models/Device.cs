//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{    
    public partial class Device : BaseModel
    {
        public Device()
        {
            this.Tables = new HashSet<Table>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Table> Tables { get; set; }
    }
}
