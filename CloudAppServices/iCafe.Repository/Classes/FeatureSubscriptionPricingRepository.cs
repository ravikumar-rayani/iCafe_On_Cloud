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
    public class FeatureSubscriptionPricingRepository : RepositoryBase<FeatureSubscriptionPricing, int>, IFeatureSubscriptionPricingRepository
    {
        public FeatureSubscriptionPricingRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(FeatureSubscriptionPricing entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(FeatureSubscriptionPricing entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
