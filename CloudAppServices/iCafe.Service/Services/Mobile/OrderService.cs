using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;
using iCafe.Repository.Classes;
using iCafe.Common.Utilities;
using iCafe.DTO.Client;

namespace iCafe.Service.Services.Mobile
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly ISubOrderDetailRepository subOrderDetailRepository;
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly int[] visibleOrderStatus = { 1, 2, 4 };

        public OrderService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.orderRepository = new OrderRepository(dbFactory);
            this.orderDetailRepository = new OrderDetailRepository(dbFactory);
            this.subOrderDetailRepository = new SubOrderDetailRepository(dbFactory);
            this.itemRepository = new ItemRepository(dbFactory);
            this.userRepository = new UserRepository(dbFactory);
            this.customerRepository = new CustomerRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }
        #region Get Methods

        public async Task<OrderClientDTO> GetCustomerCurrentOrders(int customerId, int userId, int orderId = 0)
        {
            OrderClientDTO orderResult = null;
            Order order = null;
            order = orderId > 0 ?
                orderRepository.GetById(orderId) :
                orderRepository.GetMany(o => o.CustomerId.Equals(customerId) && o.CreatedBy.Equals(userId) && o.PaymentStatusId.Equals(1)).FirstOrDefault(); //&& order.PaymentStatusId.Equals(1));
            if (order != null && order.CustomerId.Equals(customerId) && order.CreatedBy.Equals(userId) && order.PaymentStatusId.Equals(1))
            {
                orderResult = new OrderClientDTO();
                orderResult.Id = order.Id;
                orderResult.PaymentStatusId = order.PaymentStatusId;
                orderResult.TotalPrice = order.TotalPrice;
                orderResult.UserId = userId;
                orderResult.customerId = customerId;
                foreach (var suborder in orderDetailRepository.GetAll().Where(od => 
                                                        od.OrderId.Equals(orderId) && visibleOrderStatus.Contains(od.OrderStatusId)).ToList())
                {
                    if (orderResult.SubOrders == null) 
                        orderResult.SubOrders = new List<OrderDetailClientDTO>();
                    var suborderDetail = new OrderDetailClientDTO();
                    suborderDetail.SubOrderId = suborder.SubOrderId;
                    suborderDetail.OrderStatusId = suborder.OrderStatusId;
                    suborderDetail.SubTotalPrice = 0.00m;
                    foreach (var ordereditem in subOrderDetailRepository.GetAll().Where(o => 
                                                                o.SubOrderId.Equals(suborder.SubOrderId)))
                    {
                        if (suborderDetail.OrderItems == null) 
                            suborderDetail.OrderItems = new List<OrderItemDetailClientDTO>();
                        var item = new OrderItemDetailClientDTO();
                        item.ItemId = ordereditem.ItemId;
                        item.OrderQuantity = ordereditem.OrderQuantity;
                        item.OrderPreferences = ordereditem.OrderPreferences;
                        suborderDetail.OrderItems.Add(item);
                    }
                    orderResult.SubOrders.Add(suborderDetail);
                }
            }
            return orderResult;
        }

        public async Task<OrderClientDTO> GetCustomerCurrentOrders(int orderId)
        {
            OrderClientDTO orderResult = null;
            Order order = null;
            order = orderRepository.GetById(orderId);
            if (order != null && order.PaymentStatusId.Equals(1))
            {
                orderResult = new OrderClientDTO();
                orderResult.Id = order.Id;
                orderResult.PaymentStatusId = order.PaymentStatusId;
                orderResult.TotalPrice = order.TotalPrice;
                orderResult.UserId = (int)order.CreatedBy;
                orderResult.customerId = order.CustomerId;
                foreach (var suborder in orderDetailRepository.GetAll().Where(od =>
                                                        od.OrderId.Equals(orderId) &&
                                                        visibleOrderStatus.Contains(od.OrderStatusId)).ToList())
                {
                    if (orderResult.SubOrders == null)
                        orderResult.SubOrders = new List<OrderDetailClientDTO>();
                    var suborderDetail = new OrderDetailClientDTO();
                    suborderDetail.SubOrderId = suborder.SubOrderId;
                    suborderDetail.OrderStatusId = suborder.OrderStatusId;
                    suborderDetail.SubTotalPrice = 0.00m;
                    var test = subOrderDetailRepository.GetAll();
                    foreach (var ordereditem in subOrderDetailRepository.GetAll().Where(o =>
                                                                o.SubOrderId.Equals(suborder.SubOrderId)))
                    {
                        if (suborderDetail.OrderItems == null)
                            suborderDetail.OrderItems = new List<OrderItemDetailClientDTO>();
                        var item = new OrderItemDetailClientDTO();
                        item.ItemId = ordereditem.ItemId;
                        item.OrderQuantity = ordereditem.OrderQuantity;
                        item.OrderPreferences = ordereditem.OrderPreferences;
                        suborderDetail.OrderItems.Add(item);
                    }
                    orderResult.SubOrders.Add(suborderDetail);
                }
            }
            return orderResult;
        }

        public async Task<List<OrderClientDTO>> GetWaiterCurrentOrders(int waiterId)
        {
            List<OrderClientDTO> orderResult = null;

            if(userRepository.GetById(waiterId).RoleId.Equals(5))

            foreach(var order in orderRepository.GetMany(o => o.CreatedBy.Equals(waiterId) && o.PaymentStatusId.Equals(1)).ToList())
            {
                if (orderResult == null)
                    orderResult = new List<OrderClientDTO>();
                var _order = new OrderClientDTO();
                _order.Id = order.Id;
                _order.PaymentStatusId = order.PaymentStatusId;
                _order.TotalPrice = order.TotalPrice;
                _order.UserId = (int)order.CreatedBy;
                _order.customerId = order.CustomerId;
                foreach (var suborder in orderDetailRepository.GetAll().Where(od =>
                                                        od.OrderId.Equals(_order.Id) && visibleOrderStatus.Contains(od.OrderStatusId)).ToList())
                {
                    if (_order.SubOrders == null)
                        _order.SubOrders = new List<OrderDetailClientDTO>();
                    var suborderDetail = new OrderDetailClientDTO();
                    suborderDetail.SubOrderId = suborder.SubOrderId;
                    suborderDetail.OrderStatusId = suborder.OrderStatusId;
                    suborderDetail.SubTotalPrice = 0.00m;
                    foreach (var ordereditem in subOrderDetailRepository.GetAll().Where(o =>
                                                                o.SubOrderId.Equals(suborder.SubOrderId)))
                    {
                        if (suborderDetail.OrderItems == null)
                            suborderDetail.OrderItems = new List<OrderItemDetailClientDTO>();
                        var item = new OrderItemDetailClientDTO();
                        item.ItemId = ordereditem.ItemId;
                        item.OrderQuantity = ordereditem.OrderQuantity;
                        item.OrderPreferences = ordereditem.OrderPreferences;
                        suborderDetail.OrderItems.Add(item);
                    }
                    _order.SubOrders.Add(suborderDetail);
                }
                orderResult.Add(_order);
            }
            return orderResult;
        }
        #endregion

        #region Post Methods

        public async Task<OrderClientDTO> PlaceOrder(int userId, int customerId, int orderId, OrderItem[] items)
        {
            return new OrderClientDTO();
        }

        public int Add(Order entity)
        {
            return orderRepository.AutoAdd(entity).Id;
        }

        public int Add(OrderDetail entity)
        {
            return orderDetailRepository.AutoAdd(entity).SubOrderId;
        }

        public void Add(SubOrderDetail entity)
        {

        }

        #endregion

        #region Update Methods

        public void Update(Order entity)
        {

        }

        public void Update(OrderDetail entity)
        {

        }

        public void Update(SubOrderDetail entity)
        {

        }

        #endregion

        #region Delete Methods

        public void DeleteOrder(int id)
        {

        }

        public void DeleteOrderDetail(int id)
        {

        }

        public void DeleteSubOrderDetail(int id)
        {

        }

        public void DeleteSubOrderDetailItem(int SubOrderId, int itemId)
        {

        }

        #endregion

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}