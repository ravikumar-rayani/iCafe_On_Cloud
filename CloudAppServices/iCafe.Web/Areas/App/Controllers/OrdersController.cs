using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCafe.Web.Controllers;
using iCafe.Web.Areas.App.ViewModels;

namespace iCafe.Web.Areas.App.Controllers
{
    public class OrdersController : BaseController
    {
        //
        // GET: /Orders/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {
            List<OrderVM> orders = new List<OrderVM>() { 
                new OrderVM(){ OrderId = 1234, Customer = "Customer", UserName = "User", TotalPrice = 1000.00m, PaymentStatus = "paid", 
                             PaymentType="cashless", RatingOnFood=4,RatingOnService=3, Feedback="not bad", CreatedOn= DateTime.Now,
                             SubOrders= new List<SubOrder>(){
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now.Date,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now.Date,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                             }
                },
                new OrderVM(){ OrderId = 2234, Customer = "Customer", UserName = "User", TotalPrice = 1000.00m, PaymentStatus = "paid", 
                             PaymentType="cashless", RatingOnFood=4,RatingOnService=3, Feedback="not bad", CreatedOn= DateTime.Now,
                             SubOrders= new List<SubOrder>(){
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                                        new SubOrder(){ SubOrderId=234, SubTotalPrice=500.00m, OrderStatus="Delivered", CreatedOn=DateTime.Now,
                                                        SubOrderDetails= new List<SubOrderDetail>(){ 
                                                                         new SubOrderDetail(){ ItemName = "Soup", Quantity=1, ItemType="regular", AppliedPrice=100.00m},
                                                                         new SubOrderDetail(){ ItemName = "Starter", Quantity=1, ItemType="regular", AppliedPrice=150.00m},
                                                                         new SubOrderDetail(){ ItemName = "Biryani", Quantity=1, ItemType="regular", AppliedPrice=250.00m},
                                                        }
                                        },
                             }
                },
            };

            return View(orders);
        }
	}
}