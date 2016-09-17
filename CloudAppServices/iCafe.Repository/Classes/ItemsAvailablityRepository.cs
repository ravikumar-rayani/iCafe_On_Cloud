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
    public class ItemsAvailablityRepository : RepositoryBase<ItemsAvailablity, int>, IItemsAvailablityRepository
    {
        public ItemsAvailablityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(ItemsAvailablity entity)
        {
            base.Add(entity);
        }

        public override void Update(ItemsAvailablity entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
