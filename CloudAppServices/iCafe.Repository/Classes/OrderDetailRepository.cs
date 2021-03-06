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
    public class OrderDetailRepository: RepositoryBase<OrderDetail, int>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        
        public override void Add(OrderDetail entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override OrderDetail AutoAdd(OrderDetail entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(OrderDetail entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }

    }
}
