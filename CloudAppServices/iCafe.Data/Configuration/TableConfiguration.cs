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
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.IsMultipleMode).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            //HasRequired(p => p.User).WithMany(i => i.Tables).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Tables).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
