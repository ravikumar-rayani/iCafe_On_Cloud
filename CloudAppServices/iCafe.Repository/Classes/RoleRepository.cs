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
    public class RoleRepository : RepositoryBase<Role, int>, IRoleRepository
    {
        public RoleRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Role GetItemByName(string RoleName)
        {
            var role = this.DbContext.Roles.Where(c => c.Name == RoleName).FirstOrDefault();

            return role;
        }

        public override void Add(Role entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Role entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
