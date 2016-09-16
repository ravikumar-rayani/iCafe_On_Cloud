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
    public class DeviceConfiguration: EntityTypeConfiguration<Device>
    {
        public DeviceConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Devices");
            else
                ToTable("Devices", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.AccountId).IsRequired().HasColumnType("int");
            Property(p => p.BranchId).HasColumnType("int");

            //Foreign Keys
            HasRequired(p => p.Account).WithMany(i => i.Devices).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(true);
            HasRequired(p => p.Branch).WithMany(i => i.Devices).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Devices).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Devices).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
