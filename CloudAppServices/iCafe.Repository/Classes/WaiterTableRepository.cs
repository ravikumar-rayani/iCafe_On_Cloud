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
    public class WaiterTableRepository : RepositoryBase<WaiterTable, int>, IWaiterTableRepository
    {
        public WaiterTableRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(WaiterTable entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(WaiterTable entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
