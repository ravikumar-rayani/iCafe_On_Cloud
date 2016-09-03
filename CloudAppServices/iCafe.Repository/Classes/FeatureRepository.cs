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
    public class FeatureRepository: RepositoryBase<Feature, int>, IFeatureRepository
    {
        public FeatureRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Feature GetFeatureByName(string FeatureName)
        {
            var feature = this.DbContext.Features.Where(c => c.Name == FeatureName).FirstOrDefault();

            return feature;
        }

        public override void Add(Feature entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Feature entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
