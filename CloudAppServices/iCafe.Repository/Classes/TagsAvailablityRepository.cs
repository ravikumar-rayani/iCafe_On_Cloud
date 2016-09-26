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
    public class TagsAvailablityRepository : RepositoryBase<TagsAvailablity, int>, ITagsAvailablityRepository
    {
        public TagsAvailablityRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(TagsAvailablity entity)
        {
            base.Add(entity);
        }

        public override void Update(TagsAvailablity entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
