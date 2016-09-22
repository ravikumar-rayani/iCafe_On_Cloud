using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.DTO.Client;
using iCafe.Data;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Service.Services
{
    interface IOrderService
    {

        #region Get Methods

        IEnumerable<OrderClientDTO> GetOrders();

        IEnumerable<OrderClientDTO> GetOrdersByCustomerId(int CustomerId);

        #endregion

        #region Add Methods

        void Add(Order entity);

        void Add(OrderDetail entity);

        void Add(SubOrderDetail entity);

        #endregion

        #region Update Methods

        void Update(Order entity);

        void Update(OrderDetail entity);

        void Update(SubOrderDetail entity);

        #endregion

        #region Delete Methods

        void DeleteOrder(int id);

        void DeleteOrderDetail(int id);

        void DeleteSubOrderDetail(int id);

        void DeleteSubOrderDetailItem(int SubOrderId, int itemId);

        #endregion

        void Save();
    }
}
