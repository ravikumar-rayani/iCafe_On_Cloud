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
    class TagConfiguration: EntityTypeConfiguration<Tag>
    {
        public TagConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Tags");
            else
                ToTable("Tags", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            //HasRequired(p => p.User).WithMany(i => i.Tags).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Tags).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
