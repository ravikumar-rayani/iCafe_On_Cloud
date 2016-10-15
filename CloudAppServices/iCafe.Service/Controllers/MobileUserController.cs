using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iCafe.Service.Services.Mobile;
using iCafe.DTO.Server;
using iCafe.DTO.Client;
using iCafe.Entity;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace iCafe.Service.Controllers
{
    [RoutePrefix("api/Mobile/User")]
    public class MobileUserController : ApiController
    {
        private readonly IUserService _service;

        public MobileUserController() : this(new UserService())
        {
        }
        public MobileUserController(IUserService service)
        {
            _service = service;
        }

        #region Validation Apis

        [Route("Login")]
        [Route("Signin")]
        [Route("Authenticate")]
        [HttpPost]
        public async Task<IHttpActionResult> Authenticate([FromBody] Credentails _credentails)
        {
            var role = await _service.Authenticate(_credentails.username, _credentails.password);
            if (role == -1)
            {
                return NotFound();
            }
            return Ok(role);
        }

        #endregion

        #region GetApis

        #region GetAll

        [Route("AllItems")]
        public IEnumerable<Role> GetRoles()
        {
            var roles = _service.GetRoles();
            return roles;
        }

        [Route("AllItemCategories")]
        public IEnumerable<User> GetUsers()
        {
            var users = _service.GetUsers();
            return users;
        }

        [Route("AllTags")]
        public IEnumerable<Feature> GetFeatures()
        {
            var features = _service.GetFeatures();
            return features;
        }

        #endregion GetAll


        [ResponseType(typeof(WaiterInfoClientDTO))]
        [Route("{waiterId}/WaiterInfo")]
        public async Task<IHttpActionResult> GetWaiterInfo(int waiterId)
        {
            var waiterTables = await _service.GetWaiterInfo(waiterId);
            if (waiterTables.assignedTables != null && waiterTables.assignedTables.Count() > 0)
            {
                return Ok(waiterTables);
            }
            return NotFound();            
        }
        

        #endregion

        #region Post Apis

        [HttpPost]
        [Route("addRole")]
        public IHttpActionResult PostRole([FromBody] Role role)
        {
            _service.Add(role);
            _service.Save();
            return Ok();
        }

        [HttpPost]
        [Route("addUser")]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            _service.Add(user);
            _service.Save();
            return Ok();
        }

        [HttpPost]
        [Route("addRoleAccess")]
        public IHttpActionResult PostRoleAccess([FromBody] RoleFeatureAccess roleAccess)
        {
            _service.Add(roleAccess);
            _service.Save();
            return Ok();
        }

        [HttpPost]
        [Route("addFeature")]
        public IHttpActionResult PostFeature([FromBody] Feature feature)
        {
            _service.Add(feature);
            _service.Save();
            return Ok();
        }

        #endregion

        #region Put Apis

        [HttpPut]
        [Route("updateRole/{id}")]
        public IHttpActionResult PutRole(int id, [FromBody] Role role)
        {
            _service.Update(role);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateUser/{username}")]
        public IHttpActionResult PutTag(string username, [FromBody] User user)
        {
            _service.Update(user);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateRoleAccess/{roleId}/{featureId}")]
        public IHttpActionResult PutRoleAccess(int roleId, int featureId, [FromBody] RoleFeatureAccess roleAccess)
        {
            _service.Update(roleAccess);
            _service.Save();
            return Ok();
        }

        [HttpPut]
        [Route("updateFeature/{id}")]
        public IHttpActionResult PutFeature(int id, [FromBody] Feature feature)
        {
            _service.Update(feature);
            _service.Save();
            return Ok();
        }

        #endregion

        #region Delete Apis

        [HttpDelete]
        [Route("deleteRoles/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            //System.Diagnostics.Debugger.Break();  
            _service.DeleteRole(id);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteUser/{userId}")]
        public IHttpActionResult DeleteUser(int userId)
        {
            _service.DeleteUser(userId);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleItemtag/{roleId}/{featureId}")]
        public IHttpActionResult DeleteRoleAccess(int roleId, int featureId)
        {
            _service.DeleteRoleAccess(roleId, featureId);
            _service.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteFeature/{id}")]
        public IHttpActionResult DeleteFeature(int id)
        {
            _service.DeleteFeature(id);
            _service.Save();
            return Ok();
        }

        #endregion
    }
}
