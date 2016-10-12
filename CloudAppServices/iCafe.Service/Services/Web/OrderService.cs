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
using iCafe.DTO.Server;

namespace iCafe.Service.Services.Web
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly ISubOrderDetailRepository subOrderDetailRepository;
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

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

        public IEnumerable<OrderDetailServerDTO> GetOrders()
        {
            var orders = new List<OrderDetailServerDTO>();
            foreach (var order in orderRepository.GetAll())
            {
                orders.Add(new OrderDetailServerDTO()
                {
                    Id = order.Id,
                    PaymentStatusId = order.PaymentStatusId,
                    TotalPrice = order.TotalPrice,
                    SubOrderIds = orderDetailRepository.GetAll().Where(o => o.OrderId.Equals(order.Id)).Select(od => od.SubOrderId).ToArray()

                });
            }
            return orders;
        }

        public IEnumerable<OrderDetailServerDTO> GetOrdersByCustomerId(int CustomerId)
        {

            var orders = new List<OrderDetailServerDTO>();
            foreach (var order in orderRepository.GetAll().Where(o => o.CustomerId.Equals(CustomerId)))
            {
                orders.Add(new OrderDetailServerDTO()
                {
                    Id = order.Id,
                    PaymentStatusId = order.PaymentStatusId,
                    TotalPrice = order.TotalPrice,
                    SubOrderIds = orderDetailRepository.GetAll().Where(o => o.OrderId.Equals(order.Id)).Select(od => od.SubOrderId).ToArray()

                });
            }
            return orders;
        }

        #endregion

        #region Add Methods

        public void Add(Order entity)
        {

        }

        public void Add(OrderDetail entity)
        {

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

        void Save()
        {
            unitOfWork.Commit();
        }
    }
}