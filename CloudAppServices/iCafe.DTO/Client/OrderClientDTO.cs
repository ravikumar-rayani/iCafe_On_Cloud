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
        public int PaymentStatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int customerId { get; set; }
        public List<OrderDetailClientDTO> SubOrders { get; set; }
    }

    public class OrderDetailClientDTO
    {
        public int SubOrderId { get; set; }
        public int OrderStatusId { get; set; }
        public Decimal SubTotalPrice { get; set; }
        public List<OrderItemDetailClientDTO> OrderItems { get; set; }

    }

    public class OrderItemDetailClientDTO
    {
        public int ItemId { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderPreferences { get; set; }
    }

    public class OrderRequestParameters
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }

    public class OrderingParameters
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderItem[] Items { get; set; }

    }

    public class OrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Prefences { get; set; }
    }
}
