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
    public class WaiterTableConfiguration : EntityTypeConfiguration<WaiterTable>
    {
        public WaiterTableConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("WaiterTables");
            else
                ToTable("WaiterTables", Schema);

            HasKey(p => new { p.AccountId, p.BranchId, p.Waiter, p.TableId });
            Property(p => p.AccountId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).IsRequired().HasColumnType("INT");
            Property(p => p.Waiter).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(20);
            Property(p => p.TableId).IsRequired().HasColumnType("INT");
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.Account).WithMany(i => i.WaiterTables).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(true);
            HasRequired(p => p.Branch).WithMany(i => i.WaiterTables).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(false);
            HasRequired(p => p.User).WithMany(i => i.WaiterTables).HasForeignKey(f => f.Waiter).WillCascadeOnDelete(true);
            HasRequired(p => p.Table).WithMany(i => i.WaiterTables).HasForeignKey(f => f.TableId).WillCascadeOnDelete(false);
        }
    }
}
