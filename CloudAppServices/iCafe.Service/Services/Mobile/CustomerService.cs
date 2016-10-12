using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;
using iCafe.Repository.Classes;
using iCafe.Common.Utilities;
using iCafe.DTO.Client;

namespace iCafe.Service.Services.Mobile
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService()
        {
            var dbFactory = new DbFactory();    //("iCafe-" + "CompanyCode", "CompanyCode-" + "branchcode");
            this.customerRepository = new CustomerRepository(dbFactory);
            this.unitOfWork = new UnitOfWork(dbFactory);
        }

        #region ICustomerService Members

        #region Validation Methods

        public async Task<bool> CheckCustomerExistence(decimal phoneNo)
        {
            return customerRepository.Get(c => c.Phone.Equals(phoneNo)) == null ? false: true ;
        }

        #endregion

        #region Add Apis

        public async Task<int> Add(CustomerClientDTO _customer)
        {
            Customer customer = new Customer()
            {
                Name = _customer.Name,
                Phone = _customer.Phone,
                EmailId = _customer.EmailId,
                Address = _customer.Address,
                AccountId = 6
            };
            return customerRepository.AutoAdd(customer).Id;
        }

        #endregion

        #endregion

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}