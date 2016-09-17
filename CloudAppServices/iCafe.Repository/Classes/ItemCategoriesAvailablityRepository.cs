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
    public class ItemCategoriesAvailablityRepository 
                : RepositoryBase<ItemCategoriesAvailablity, int>, IItemCategoriesAvailablityRepository
    {
        public ItemCategoriesAvailablityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(ItemCategoriesAvailablity entity)
        {
            base.Add(entity);
        }

        public override void Update(ItemCategoriesAvailablity entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
