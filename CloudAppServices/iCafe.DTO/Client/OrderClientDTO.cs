using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Client
{
    public class OrderClientDTO : BasicClientDTO
    {
        public int Id { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public int[] SubOrderIds { get; set; }
    }
}
