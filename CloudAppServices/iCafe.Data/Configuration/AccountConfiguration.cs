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
    class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Account");
            else
                ToTable("Account", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.IsActive).IsRequired().HasColumnType("BIT");
            Property(p => p.CompanyName).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.EmailId).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(100);
            Property(p => p.IsMultiBranchesAllowed).IsRequired().HasColumnType("BIT");
            Property(p => p.MaxBranches).IsRequired().HasColumnType("int");
            Property(p => p.EndDate).IsRequired().HasColumnType("datetime2");
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.AccoutTypeId).IsRequired().HasColumnType("int");

            //Foreign Keys
            HasRequired(p => p.AccountType).WithMany(i => i.Accounts).HasForeignKey(f => f.AccoutTypeId);
            //HasRequired(p => p.User).WithMany(i => i.ItemCategories).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.ItemCategories).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
