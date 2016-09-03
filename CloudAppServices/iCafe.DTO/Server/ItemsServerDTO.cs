using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Server
{
    class ItemsServerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemCategoryId { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public string ImagePath { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public decimal Price { get; set; }
        public List<int> TagIds { get; set; }
        public string SpicyLevel { get; set; }
        public string Ingrediants { get; set; }
        public string Description { get; set; }
    }
}
