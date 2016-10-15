using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Repository.Classes
{
    public class OrderStatusRepository : RepositoryBase<OrderStatu, int>, IOrderStatusRepository
    {
        public OrderStatusRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public OrderStatu GetPaymentStatusByName(string OrderStatusName)
        {
            var orderstatus = this.DbContext.OrderStatus.Where(c => c.Name == OrderStatusName).FirstOrDefault();

            return orderstatus;
        }

        public override void Add(OrderStatu entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override OrderStatu AutoAdd(OrderStatu entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(OrderStatu entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
