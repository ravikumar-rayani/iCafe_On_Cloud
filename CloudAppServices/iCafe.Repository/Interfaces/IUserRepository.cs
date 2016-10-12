using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;

namespace iCafe.Repository.Interfaces
{
    public interface IUserRepository: IRepository<User, int>
    {
        User GetByUserName(string username);

        Task<User> GetByUserNameAsync(string username);
    }
}
