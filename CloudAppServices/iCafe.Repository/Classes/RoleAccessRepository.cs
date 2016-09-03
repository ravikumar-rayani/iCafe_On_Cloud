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
    public class RoleAccessRepository : RepositoryBase<RoleAccess, int>, IRoleAccessRepository
    {
        public RoleAccessRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public override void Add(RoleAccess entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(RoleAccess entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
