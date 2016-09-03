//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Table : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeviceID { get; set; }
        public bool IsMultipleMode { get; set; }
        public string Description { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
