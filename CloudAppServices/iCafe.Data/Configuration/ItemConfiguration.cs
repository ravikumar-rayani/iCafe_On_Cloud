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
    public class ItemConfiguration: EntityTypeConfiguration<Item>
    {
        public ItemConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("Items");
            else
                ToTable("Items", Schema);

            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(50);
            Property(p => p.Price).IsRequired().HasColumnType("DECIMAL").HasPrecision(10, 2);
            Property(p => p.Discount).HasColumnType("DECIMAL").HasPrecision(3, 2);
            Property(p => p.SpicyLevel).HasColumnType("INT");
            Property(p => p.Ingrediants).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.SmallImageUrl).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.FullImageUrl).HasColumnType("NVARCHAR").HasMaxLength(255);
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");
            Property(p => p.ItemCategoryId).IsRequired().HasColumnType("INT");
            Property(p => p.AccountId).IsRequired().HasColumnType("INT");

            //Foreign Keys
            HasRequired(p => p.ItemCategory).WithMany(i => i.Items).HasForeignKey(f => f.ItemCategoryId);
            HasRequired(p => p.Account).WithMany(i => i.Items).HasForeignKey(f => f.AccountId);
            //HasRequired(p => p.User).WithMany(i => i.Items).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.Items).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }

    }
}
