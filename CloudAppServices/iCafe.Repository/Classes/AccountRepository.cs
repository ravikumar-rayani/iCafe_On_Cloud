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
    public class AccountRepository : RepositoryBase<Account , int>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(Account entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override Account AutoAdd(Account entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(Account entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
