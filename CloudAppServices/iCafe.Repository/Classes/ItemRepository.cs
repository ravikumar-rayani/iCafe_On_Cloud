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
    public class ItemRepository: RepositoryBase<Item, int>, IItemRepository
    {
        public ItemRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Item GetItemByName(string ItemName)
        {
            var item = this.DbContext.Items.Where(c => c.Name == ItemName).FirstOrDefault();

            return item;
        }

        public override void Add(Item entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Item entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
