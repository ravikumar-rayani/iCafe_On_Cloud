using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.DTO.Client;

namespace iCafe.Service.Services.Mobile
{
    public interface ICustomerService
    {
        #region Validation Methods

        Task<bool> CheckCustomerExistence(decimal phoneNo);

        #endregion

        #region Post Apis

        Task<int> Add(CustomerClientDTO _customer);

        #endregion
    }
}
