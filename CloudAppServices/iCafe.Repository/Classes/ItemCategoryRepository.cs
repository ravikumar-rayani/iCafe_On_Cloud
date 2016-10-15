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
    public class ItemCategoryRepository: RepositoryBase<ItemCategory, int>, IItemCategoryRepository
    {
        public ItemCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public ItemCategory GetItemCategoryByName(string CategoryName)
        {
            var feature = this.DbContext.ItemCategories.Where(c => c.Name == CategoryName).FirstOrDefault();

            return feature;
        }

        public override void Add(ItemCategory entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override ItemCategory AutoAdd(ItemCategory entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(ItemCategory entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
