using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    class TagsClientDTO : BasicClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
    }
}
