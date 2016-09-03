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
    public class ItemTagRepository: RepositoryBase<ItemTag, int>, IItemTagRepository
    {
        public ItemTagRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public override void Add(ItemTag entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(ItemTag entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
