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
        public int ItemCategoryId {get; set;}
        public bool IsAvailable { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Price { get; set; }
        public int SpicyLevel { get; set; }
        public string[] Ingrediants {get; set;}
        public int[] Tags {get; set;}
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string FullImage { get; set; }
    }
}
