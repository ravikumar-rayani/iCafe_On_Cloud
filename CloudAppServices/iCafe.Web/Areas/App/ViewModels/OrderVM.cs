using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCafe.Web.Areas.App.ViewModels
{

    public class OrderVM
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentType { get; set; }
        public int RatingOnFood { get; set; }
        public int RatingOnService { get; set; }
        public string Feedback { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<SubOrder> SubOrders { get; set; }
    }

    public class SubOrder
    {
        public int SubOrderId { get; set; }
        public string OrderStatus { get; set; }
        public decimal SubTotalPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<SubOrderDetail> SubOrderDetails { get; set; }
    }

    public class SubOrderDetail
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }
        public decimal AppliedPrice { get; set; }
    }
}