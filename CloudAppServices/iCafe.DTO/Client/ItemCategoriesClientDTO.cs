using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    class ItemCategoriesClientDTO : BasicClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Description { get; set; }
    }
}
