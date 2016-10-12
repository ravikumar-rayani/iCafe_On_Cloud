using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    public class WaiterInfoClientDTO
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int[] assignedTables { get; set; }
    }
}
