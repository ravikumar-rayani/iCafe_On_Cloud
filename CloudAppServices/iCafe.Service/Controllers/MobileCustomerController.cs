using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iCafe.Entity;
using iCafe.Service.Services.Mobile;
using iCafe.DTO.Client;
using iCafe.DTO.Server;
using System.Threading.Tasks;
using System.Web.Http.Description;
using iCafe.Service.ActionFilters;

namespace iCafe.Service.Controllers
{
    [RoutePrefix("api/Mobile/Customer")]
    public class MobileCustomerController : ApiController
    {
        private readonly ICustomerService _service;

        public MobileCustomerController()
            : this(new CustomerService())
        {
        }
        public MobileCustomerController(ICustomerService service)
        {
            _service = service;
        }

        #region GetApis

        [ResponseType(typeof(bool))]
        [HttpGet]
        [Route("{phoneNo}/IsExists")]
        public async Task<IHttpActionResult> IsCustomerExists(decimal phoneNo)
        {
            var result = await _service.CheckCustomerExistence(phoneNo);
            return Ok(result);
        }

        #endregion

        #region PostApis

        [ResponseType(typeof(int))]
        [HttpPost]
        [Route("NewCustomer")]
        public async Task<IHttpActionResult> PostCustomer(CustomerClientDTO customer)
        {
            var result = await _service.Add(customer);

            return Ok(result);

        }
        #endregion
    }
}
