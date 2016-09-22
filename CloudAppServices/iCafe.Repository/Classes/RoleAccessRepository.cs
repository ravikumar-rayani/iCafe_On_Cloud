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
    public class RoleAccessRepository : RepositoryBase<RoleFeatureAccess, int>, IRoleAccessRepository
    {
        public RoleAccessRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public override void Add(RoleFeatureAccess entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(RoleFeatureAccess entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
