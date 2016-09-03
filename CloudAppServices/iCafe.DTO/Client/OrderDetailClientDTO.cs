using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    public class OrderDetailClientDTO
    {
        public int SubOrderId { get; set; }
        public int ItemId { get; set; }
        public Nullable<int> OrderQuantiry { get; set; }
        public string OrderType { get; set; }
        public string OrderPreferences { get; set; }
    }
}
