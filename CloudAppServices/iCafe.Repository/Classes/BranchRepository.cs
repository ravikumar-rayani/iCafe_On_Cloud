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
    public class BranchRepository : RepositoryBase<Branch, int>, IBranchRepository
    {
        public BranchRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(Branch entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Branch entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
