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
    public class AccountTypeFeaturesRepository : RepositoryBase<AccountTypeFeature, int>, IAccountTypeFeaturesRepository
    {
        public AccountTypeFeaturesRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(AccountTypeFeature entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(AccountTypeFeature entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
