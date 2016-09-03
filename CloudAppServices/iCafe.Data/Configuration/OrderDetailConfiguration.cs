using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class OrderDetailConfiguration: EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("OrderDetails");
            else
                ToTable("OrderDetails", Schema);

            HasKey(p => p.SubOrderId);
            Property(p => p.SubOrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.OrderId).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            
            //Foreign Keys
            HasRequired(p => p.Order).WithMany(i => i.OrderDetails).HasForeignKey(f => f.OrderId);
            //HasRequired(p => p.User).WithMany(i => i.OrderDetails).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.OrderDetails).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
