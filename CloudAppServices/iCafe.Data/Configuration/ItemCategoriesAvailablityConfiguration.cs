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
    class ItemCategoriesAvailablityConfiguration : EntityTypeConfiguration<ItemCategoriesAvailablity>
    {
        public ItemCategoriesAvailablityConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("ItemCategoriesAvailablities");
            else
                ToTable("ItemCategoriesAvailablities", Schema);

            HasKey(p => new { p.ItemCategoryId, p.BranchId });
            Property(p => p.ItemCategoryId).IsRequired().HasColumnType("INT");
            Property(p => p.BranchId).IsRequired().HasColumnType("INT");
            Property(p => p.IsAvailable).IsRequired().HasColumnType("BIT");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.ItemCategory).WithMany(i => i.ItemCategoriesAvailablities).HasForeignKey(f => f.ItemCategoryId);
            HasRequired(p => p.Branch).WithMany(i => i.ItemCategoriesAvailablities).HasForeignKey(f => f.BranchId);
        }
    }
}
