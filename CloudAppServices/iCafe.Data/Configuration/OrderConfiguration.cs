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
            Property(p => p.CustomerId).IsRequired().HasColumnType("INT");
            Property(p => p.TotalPrice).IsRequired().HasColumnType("DECIMAL").HasPrecision(10, 2);
            Property(p => p.RatingOnFood).HasColumnType("INT");
            Property(p => p.RatingOnService).HasColumnType("INT");
            Property(c => c.Feedback).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.PaymentStatusId).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.AccountId).IsRequired().HasColumnType("int");
            Property(p => p.BranchId).HasColumnType("int");

            //Foreign Keys
            HasRequired(p => p.Customer).WithMany(i => i.Orders).HasForeignKey(f => f.CustomerId).WillCascadeOnDelete(true);
            HasRequired(p => p.Account).WithMany(i => i.Orders).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(false);
            HasRequired(p => p.Branch).WithMany(i => i.Orders).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Orders).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Orders).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
