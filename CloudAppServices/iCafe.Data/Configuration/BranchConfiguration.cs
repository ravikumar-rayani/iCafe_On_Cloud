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
    class BranchConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Branches");
            else
                ToTable("Branches", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasColumnType("NVARCHAR");
            Property(p => p.AccountId).IsRequired().HasColumnType("INT");
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.Account).WithMany(i => i.Branches).HasForeignKey(f => f.AccountId);
            //HasRequired(p => p.User).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.SubOrderDetails).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
