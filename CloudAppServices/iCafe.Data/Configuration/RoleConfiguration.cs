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
    class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Roles");
            else
                ToTable("Roles", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(P => P.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            //HasRequired(p => p.User).WithMany(i => i.Roles).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Roles).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
