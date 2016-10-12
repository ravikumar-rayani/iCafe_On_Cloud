using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Data.Infrastructure;
using iCafe.Entity;
using iCafe.Repository.Interfaces;

namespace iCafe.Service.Services.Web
{
    public interface IUserService
    {
        #region Get Methods

        string RegisterDevice(string username, string password, string DeviceUniqueId);

        string Signin(string username, string password);
 
        #endregion

        #region Get Methods
        //Get data
        IEnumerable<User> GetUsers();

        IEnumerable<Role> GetRoles();
        
        IEnumerable<Feature> GetFeatures();
        //IEnumerable<User> GetUsersByRoleId();
        //User GetUserById();
        //User GetUserFeaturesByID();
        //UserDTO GetUsersById();

        #endregion

        #region Add Methods

        void Add(Role role);

        void Add(User user);

        void Add(Feature feature);

        void Add(RoleFeatureAccess roleAccess);

        #endregion

        #region Update Methods

        void Update(Role role);

        void Update(User user);

        void Update(Feature feature);

        void Update(RoleFeatureAccess roleAccess);

        #endregion

        #region Delete Methods

        void DeleteRole(int id);

        void DeleteUser(int userId);

        void DeleteRoleAccess(int roleId, int featureId);

        void DeleteFeature(int id);

        #endregion

        void Save();
        
    }
}
