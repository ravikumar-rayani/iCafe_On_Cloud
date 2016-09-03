using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.Model.Models
{
    public abstract class BaseModel
    {
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        //public virtual User User { get; set; }
    }
}
