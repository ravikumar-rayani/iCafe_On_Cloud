using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class RoleAccessConfiguration: EntityTypeConfiguration<RoleAccess>
    {
        public RoleAccessConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("RoleAccess");
            else
                ToTable("RoleAccess", Schema);
 
            HasKey(s => new { s.RoleID, s.FeatureID });
            Property(c => c.WirtePermissions).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");


            //Foreign Keys
            //HasRequired(p => p.User).WithMany(i => i.RoleAccess).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.RoleAccess).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
