using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Entity;
using iCafe.Data.Infrastructure;
using iCafe.Repository.Interfaces;

namespace iCafe.Repository.Classes
{
    public class DeviceRepository: RepositoryBase<Device, int>, IDeviceRepository
    {
        public DeviceRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Device GetDeviceByName(string DeviceName)
        {
            var device = this.DbContext.Devices.Where(c => c.Name == DeviceName).FirstOrDefault();

            return device;
        }

        public override void Add(Device entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
        }

        public override Device AutoAdd(Device entity)
        {
            entity.CreatedOn = DateTime.Now;
            return base.AutoAdd(entity);
        }

        public override void Update(Device entity)
        {
            entity.ModifiedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
