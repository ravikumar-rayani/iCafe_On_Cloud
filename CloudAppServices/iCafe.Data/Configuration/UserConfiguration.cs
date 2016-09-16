using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Users");
            else
                ToTable("Users", Schema);

            HasKey(p => p.UserName);
            Property(p => p.UserName).HasColumnType("NVARCHAR").HasMaxLength(20);            
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation( new IndexAttribute("IX_UserName", 1) { IsUnique = true }));
            Property(p => p.FirstName).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.LastName).HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(c => c.Password).IsRequired();
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.AccountId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).HasColumnType("INT");

            //Foreign Keys
            HasRequired(p => p.Role).WithMany(i => i.Users).HasForeignKey(f => f.RoleId).WillCascadeOnDelete(true);
            HasRequired(p => p.Account).WithMany(i => i.Users).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(false);
            HasRequired(p => p.Branch).WithMany(i => i.Users).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Users).HasForeignKey(f => f.CreatedBy);
            //HasRequired(p => p.User).WithMany(i => i.Users).HasForeignKey(f => f.ModifiedBy);
        }
    }
}
