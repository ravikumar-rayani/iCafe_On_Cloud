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
    public class PaymentStatusRepository : RepositoryBase<PaymentStatu, int>, IPaymentStatusRepository
    {
        public PaymentStatusRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public PaymentStatu GetPaymentStatusByName(string PaymentStatusName)
        {
            var paymentstatus = this.DbContext.PaymentStatus.Where(c => c.Name == PaymentStatusName).FirstOrDefault();

            return paymentstatus;
        }

        public override void Add(PaymentStatu entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override PaymentStatu AutoAdd(PaymentStatu entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(PaymentStatu entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
