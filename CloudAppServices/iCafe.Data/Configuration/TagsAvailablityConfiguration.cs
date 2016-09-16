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
    class TagsAvailablityConfiguration : EntityTypeConfiguration<TagsAvailablity>
    {
        public TagsAvailablityConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("TagsAvailablities");
            else
                ToTable("TagsAvailablities", Schema);

            HasKey(p => new { p.TagId, p.BranchId });
            Property(p => p.TagId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).IsRequired().HasColumnType("INT");
            Property(p => p.IsAvailable).IsRequired().HasColumnType("BIT");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.Tag).WithMany(i => i.TagsAvailablities).HasForeignKey(f => f.TagId);
            HasRequired(p => p.Branch).WithMany(i => i.TagsAvailablities).HasForeignKey(f => f.BranchId);
        }
    }
}
