using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    class ItemtagsClientDTO : BasicClientDTO
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
    }
}
