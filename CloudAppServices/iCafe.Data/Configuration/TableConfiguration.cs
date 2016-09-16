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
    class TableConfiguration: EntityTypeConfiguration<Table>
    {
        public TableConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Tables");
            else
                ToTable("Tables", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.DeviceID).IsRequired().HasColumnType("INT");
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.IsMultipleMode).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.AccountId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).HasColumnType("INT");

            //Foreign Keys
            HasRequired(p => p.Device).WithMany(i => i.Tables).HasForeignKey(f => f.DeviceID).WillCascadeOnDelete(true);
            HasRequired(p => p.Account).WithMany(i => i.Tables).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(false);
            HasRequired(p => p.Branch).WithMany(i => i.Tables).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(false);
        }
    }
}
