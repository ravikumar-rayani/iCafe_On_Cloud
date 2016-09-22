using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;

namespace iCafe.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        iCafeEntities Init();
    }
}
