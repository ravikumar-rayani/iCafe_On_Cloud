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
    class OrderConfiguration: EntityTypeConfiguration<Order>
    {
        public OrderConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Orders");
            else
                ToTable("Orders", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.PaymentStatus).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //HasRequired(p => p.User).WithMany(i => i.Orders).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Orders).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
