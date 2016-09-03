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
    public class TagRepository : RepositoryBase<Tag, int>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Item GetTagByName(string TagName)
        {
            var tag = this.DbContext.Items.Where(c => c.Name == TagName).FirstOrDefault();

            return tag;
        }

        public override void Add(Tag entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Tag entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
