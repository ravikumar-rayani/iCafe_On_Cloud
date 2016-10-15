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
    public class SubscriptionTypeRepository : RepositoryBase<SubscriptionType, int>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(SubscriptionType entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override SubscriptionType AutoAdd(SubscriptionType entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(SubscriptionType entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
