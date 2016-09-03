using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Repository.Classes
{
    public class PaymentStatusRepository: RepositoryBase<PaymentStatus, int>, IPaymentStatusRepository
    {
        public PaymentStatusRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public PaymentStatus GetPaymentStatusByName(string PaymentStatusName)
        {
            var paymentstatus = this.DbContext.PaymentStatus.Where(c => c.Name == PaymentStatusName).FirstOrDefault();

            return paymentstatus;
        }

        public override void Add(PaymentStatus entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(PaymentStatus entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
