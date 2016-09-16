using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public partial class ItemCategoriesAvailablity
    {
        public int ItemCategoryId { get; set; }
        public int BranchId { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
    }
}
