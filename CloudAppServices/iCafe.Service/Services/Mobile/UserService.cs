using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;
using iCafe.Repository.Classes;
using System.Threading.Tasks;
using iCafe.DTO.Client;

namespace iCafe.Service.Services.Mobile
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IFeatureRepository featureRepository;
        private readonly IRoleAccessRepository roleAccessRepository;
        private readonly IWaiterTableRepository waiterTableRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.userRepository = new UserRepository(dbFactory);
            this.roleRepository = new RoleRepository(dbFactory);
            this.featureRepository = new FeatureRepository(dbFactory);
            this.roleAccessRepository = new RoleAccessRepository(dbFactory);
            this.waiterTableRepository = new WaiterTableRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        #region Validation Methods

        public string RegisterDevice(string username, string password, string DeviceUniqueId)
        {
            User user = userRepository.GetByUserName(username);
            if (user != null)
            {
                if (user.Password.Equals(password) && user.RoleId == 1)
                {
                    return "Connected";
                }
            }
            return "Connection failed";
        }

        public async Task<int> Authenticate(string username, string password)
        {
            User user = userRepository.GetByUserName(username);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    return user.RoleId; //roleRepository.GetById(user.RoleId).Name;
                }
            }
            return -1;
        }

        #endregion

        #region Get Methods

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }
        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.GetAll();
        }
        public IEnumerable<Feature> GetFeatures()
        {
            return featureRepository.GetAll();
        }

        public async Task<WaiterInfoClientDTO> GetWaiterInfo(int waiterId)
        {
            WaiterInfoClientDTO waiterInfo = null;
            if (userRepository.GetById(waiterId).RoleId.Equals(5))
            {
                waiterInfo = new WaiterInfoClientDTO();
                waiterInfo.Name = userRepository.GetById(waiterId).FirstName;
                waiterInfo.ImagePath = ""; // userRepository.GetById(username).Imagepath;
                if (waiterTableRepository.Any(w => w.WaiterId.Equals(waiterId)))
                    waiterInfo.assignedTables = waiterTableRepository.GetMany(w => w.WaiterId.Equals(waiterId)).Select(t => t.TableId).ToArray();
            }
            return waiterInfo;
        }
        //public IEnumerable<User> GetUserFeaturesByID()
        //{
            
        //}
        //public IEnumerable<User> GetUsersByRole()
        //{

        //}

        //public IEnumerable<User> GetUsersById();

        //public User GetUsersById();

        #endregion

        #region Add Methods

        public void Add(Role role)
        {
            roleRepository.Add(role);
        }

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public void Add(Feature feature)
        {
            featureRepository.Add(feature);
        }

        public void Add(RoleFeatureAccess roleAccess)
        {
            roleAccessRepository.Add(roleAccess);
        }

        #endregion

        #region Update Methods

        public void Update(Role role)
        {
            roleRepository.Update(role);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        public void Update(Feature feature)
        {
            featureRepository.Update(feature);
        }

        public void Update(RoleFeatureAccess roleAccess)
        {
            roleAccessRepository.Update(roleAccess);
        }

        #endregion

        #region Delete Methods

        public void DeleteRole(int id)
        {
            roleRepository.Delete(id);
        }

        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
        }

        public void DeleteRoleAccess(int roleId, int featureId)
        {
            roleAccessRepository.Delete(x => x.RoleID == roleId && x.FeatureID == featureId);
        }

        public void DeleteFeature(int id)
        {
            featureRepository.Delete(id);
        }

        #endregion

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}