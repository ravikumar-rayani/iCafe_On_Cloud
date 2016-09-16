using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class SubOrderDetailConfiguration: EntityTypeConfiguration<SubOrderDetail>
    {
        public SubOrderDetailConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("SubOrderDetails");
            else
                ToTable("SubOrderDetails", Schema);

            HasKey(s => new { s.SubOrderId, s.ItemId });
            Property(p => p.OrderQuantity).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.OrderDetail).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.SubOrderId);
            HasRequired(p => p.Item).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.ItemId);
            //HasRequired(p => p.User).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
