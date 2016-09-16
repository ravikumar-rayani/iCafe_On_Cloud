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
    public class CustomerConfiguration: EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Customers");
            else
                ToTable("Customers", Schema);
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasColumnType("NVARCHAR").IsRequired().HasMaxLength(50);
            Property(p => p.Phone).HasColumnType("DECIMAL").HasPrecision(12, 0).IsRequired();
            Property(p => p.EmailId).HasColumnType("NVARCHAR").HasMaxLength(100);
            Property(p => p.Address).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.Account).WithMany(i => i.Customers).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(false);
        }
    }
}
