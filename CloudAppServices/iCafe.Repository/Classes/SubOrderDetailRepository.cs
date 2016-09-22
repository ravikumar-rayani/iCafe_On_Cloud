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
    public class SubOrderDetailRepository : RepositoryBase<SubOrderDetail, int>, ISubOrderDetailRepository
    {
        public SubOrderDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        
        public override void Add(SubOrderDetail entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(SubOrderDetail entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
