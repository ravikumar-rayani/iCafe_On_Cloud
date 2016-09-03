using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    public class ItemsClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public string Image { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Price { get; set; }
        public string SpicyLevel { get; set; }
        public string Description { get; set; }
    }
}
