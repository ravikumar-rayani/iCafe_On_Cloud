using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCafe.DTO.Server
{
    public class OrderDetailServerDTO
    {
        public int Id { get; set; }
        public int PaymentStatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int customerId { get; set; }
        public int[] SubOrderIds { get; set; }
    }
}
