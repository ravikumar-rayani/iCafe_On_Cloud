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
    public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
