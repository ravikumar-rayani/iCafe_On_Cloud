using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;

namespace iCafe.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        iCafeEntities dbContext;
        readonly string accountName;
        readonly string accountbranchName;

        public DbFactory()
        {
        }

        public DbFactory(string accountName)
        {
            this.accountName = accountName;
        }

        public DbFactory(string accountName, string accountbranchName = null)
        {            
            this.accountName = accountName;            
            this.accountbranchName = accountbranchName;
        }

        public iCafeEntities Init()
        {
            if (String.IsNullOrEmpty(this.accountName))
                return dbContext ?? (dbContext = new iCafeEntities());                
            else
                return dbContext ?? (dbContext = new iCafeEntities(accountName, accountbranchName));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
