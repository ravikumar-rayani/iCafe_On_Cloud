//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class Device
    {
        public Device()
        {
            this.Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
