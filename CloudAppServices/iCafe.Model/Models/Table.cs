//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Table
    {
        public Table()
        {
            this.WaiterTables = new HashSet<WaiterTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DeviceID { get; set; }
        public bool IsMultipleMode { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Device Device { get; set; }
        public virtual ICollection<WaiterTable> WaiterTables { get; set; }
    }
}
