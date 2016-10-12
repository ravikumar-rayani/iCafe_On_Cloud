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
    [RoutePrefix("api/Mobile/Sales")]
    public class MobileOrderController : ApiController
    {
        private readonly IOrderService _service;
      
        public MobileOrderController() : this (new OrderService())
        {
        }
        public MobileOrderController(IOrderService service)
        {
            _service = service;
        }

        #region Get Apis

        [ResponseType(typeof(OrderClientDTO))]
        [HttpGet]
        [Route("GetCurrentOrderDetails")]
        /*sample parameter:{"CustomerId":"1","UserId":"2","OrderId":3}*/
        public async Task<IHttpActionResult> GetCustomerCurrentOrders([FromBody] OrderRequestParameters parameters)
        {
            if (parameters != null)
            {
                var result = parameters.OrderId > 0 ?
                            await _service.GetCustomerCurrentOrders(parameters.CustomerId, parameters.UserId, parameters.OrderId) :
                            await _service.GetCustomerCurrentOrders(parameters.CustomerId, parameters.UserId);
                if (result == null)
                {
                    NotFound();
                }
                return Ok(result);
            }
            return BadRequest();
        }


        [ResponseType(typeof(OrderClientDTO))]
        [HttpGet]
        [Route("{orderid}/GetCurrentOrderDetails")]
        public async Task<IHttpActionResult> GetCustomerCurrentOrders(int orderId)
        {
            var result = await _service.GetCustomerCurrentOrders(orderId);
            if (result == null)
            {
                NotFound();
            }
            return Ok(result);
        }


        [ResponseType(typeof(OrderClientDTO))]
        [HttpGet]
        [Route("{waiterid}/GetWaiterCurrentOrders")]
        public async Task<IHttpActionResult> GetCurrentOrdersFromWaiter(int waiterId)
        {
            var result = _service.GetWaiterCurrentOrders(waiterId);
            if (result == null)
            {
                NotFound();
            }
            return Ok(result);
        }
        #endregion
    }
}
