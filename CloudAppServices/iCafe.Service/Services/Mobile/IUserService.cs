using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Data.Infrastructure;
using iCafe.DTO.Client;
using iCafe.Entity;
using iCafe.Repository.Interfaces;

namespace iCafe.Service.Services.Mobile
{
    public interface IUserService
    {
        #region Validation Methods

        string RegisterDevice(string username, string password, string DeviceUniqueId);

        Task<int> Authenticate(string username, string password);
 
        #endregion

        #region Get Methods
        //Get data
        IEnumerable<User> GetUsers();

        IEnumerable<Role> GetRoles();
        
        IEnumerable<Feature> GetFeatures();

        Task<WaiterInfoClientDTO> GetWaiterInfo(int waiterId);

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

        void DeleteUser(int usreId);

        void DeleteRoleAccess(int roleId, int featureId);

        void DeleteFeature(int id);

        #endregion

        void Save();
        
    }
}
