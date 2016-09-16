//------------------------------------------------------------------------------
// 
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace iCafe.Model.Models
{
    public partial class User
    {
        public User()
        {
            this.WaiterTables = new HashSet<WaiterTable>();
        }

        public string UserName { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<WaiterTable> WaiterTables { get; set; }
    }
}
