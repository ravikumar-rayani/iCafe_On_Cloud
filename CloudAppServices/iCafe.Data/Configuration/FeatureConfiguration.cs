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
    public class FeatureConfiguration : EntityTypeConfiguration<Feature>
    {
        public FeatureConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Features");
            else
                ToTable("Features", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //HasRequired(p => p.User).WithMany(i => i.Features).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Features).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
