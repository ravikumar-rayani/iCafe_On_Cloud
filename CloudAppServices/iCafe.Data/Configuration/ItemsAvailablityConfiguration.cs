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
    class ItemsAvailablityConfiguration : EntityTypeConfiguration<ItemsAvailablity>
    {
        public ItemsAvailablityConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("ItemsAvailablities");
            else
                ToTable("ItemsAvailablities", Schema);

            HasKey(p => new { p.ItemId, p.BranchId });
            Property(p => p.ItemId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).IsRequired().HasColumnType("INT");
            Property(p => p.IsAvailable).IsRequired().HasColumnType("BIT");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            
            //Foreign Keys
            HasRequired(p => p.Item).WithMany(i => i.ItemsAvailablities).HasForeignKey(f => f.ItemId).WillCascadeOnDelete(false);
            HasRequired(p => p.Branch).WithMany(i => i.ItemsAvailablities).HasForeignKey(f => f.BranchId).WillCascadeOnDelete(true);
        }
    }
}
