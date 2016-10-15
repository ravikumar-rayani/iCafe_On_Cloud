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
    public class TableRepository : RepositoryBase<Table, int>, ITableRepository
    {
        public TableRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public Table GetTableByName(string TableName)
        {
            var table = this.DbContext.Tables.Where(c => c.Name == TableName).FirstOrDefault();

            return table;
        }

        public override void Add(Table entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override Table AutoAdd(Table entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(Table entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
