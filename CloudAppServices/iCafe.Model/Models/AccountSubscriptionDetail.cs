using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class AccountSubscriptionDetail
    {
        public int AccountId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int AccountTypeId { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Modified { get; set; }

        public virtual Account Account { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
