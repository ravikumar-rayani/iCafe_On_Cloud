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
    public class UserRepository: RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public override void Add(User entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(User entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }

        public User GetByUserName(string username)
        {
            return base.Get(u => u.UserName.Equals(username));
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            return base.Get(u => u.UserName.Equals(username));
        }
    }
}
