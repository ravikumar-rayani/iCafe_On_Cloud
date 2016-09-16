using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iCafe.Model.Models;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;
using iCafe.Repository.Classes;

namespace iCafe.Service.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IFeatureRepository featureRepository;
        private readonly IRoleAccessRepository roleAccessRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.userRepository = new UserRepository(dbFactory);
            this.roleRepository = new RoleRepository(dbFactory);
            this.featureRepository = new FeatureRepository(dbFactory);
            this.roleAccessRepository = new RoleAccessRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

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
        //public IEnumerable<User> GetUserFeaturesByID()
        //{
            
        //}
        //public IEnumerable<User> GetUsersByRole()
        //{

        //}

        //public IEnumerable<User> GetUsersById();

        //public User GetUsersById();
        public int Signin(string username, string password)
        {
            if(userRepository.Any(x => x.UserName.Equals(username) && x.Password.Equals(password)))
            {
                return userRepository.Get(x => x.UserName.Equals(username) && x.Password.Equals(password)).RoleId;
            }

            return -1;
        }



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

        public void DeleteUser(string username)
        {
            userRepository.Delete(username);
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