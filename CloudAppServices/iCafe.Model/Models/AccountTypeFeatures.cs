using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class AccountTypeFeatures
    {
        public int AccountTypeId { get; set; }
        public int FeatureId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
