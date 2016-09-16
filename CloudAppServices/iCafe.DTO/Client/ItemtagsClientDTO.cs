using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    public class ItemTagsClientDTO : BasicClientDTO
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
    }
}
