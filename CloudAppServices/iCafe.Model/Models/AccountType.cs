using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            this.Accounts = new HashSet<Account>();
            this.AccountSubscriptionDetails = new HashSet<AccountSubscriptionDetail>();
            this.AccountTypeFeatures = new HashSet<AccountTypeFeatures>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<AccountSubscriptionDetail> AccountSubscriptionDetails { get; set; }
        public virtual ICollection<AccountTypeFeatures> AccountTypeFeatures { get; set; }
    }
}
