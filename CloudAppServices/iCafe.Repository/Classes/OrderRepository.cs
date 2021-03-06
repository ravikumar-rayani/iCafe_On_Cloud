﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Repository.Classes
{
    public class OrderRepository: RepositoryBase<Order, int>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Add(Order entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override Order AutoAdd(Order entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }


        public override void Update(Order entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
