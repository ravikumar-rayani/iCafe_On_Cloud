﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Repository.Classes
{
    public class CustomerRepository: RepositoryBase<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Customer GetCustomerByName(string CustomerName)
        {
            var customer = this.DbContext.Customers.Where(c => c.Name == CustomerName).FirstOrDefault();

            return customer;
        }

        public override void Add(Customer entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override void Update(Customer entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }

    }
}