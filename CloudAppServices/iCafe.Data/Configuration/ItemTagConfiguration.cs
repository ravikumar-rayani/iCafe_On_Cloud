using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class ItemTagConfiguration: EntityTypeConfiguration<ItemTag>
    {
        public ItemTagConfiguration(string Schema = null)
        {
            if (string.IsNullOrEmpty(Schema))
                ToTable("ItemTags");
            else
                ToTable("ItemTags", Schema);

            HasKey(s => new { s.ItemID, s.TagID, s.AccountId });
            Property(c => c.TagID).IsRequired();
            Property(c => c.ItemID).IsRequired();
            Property(c => c.AccountId).IsRequired();
            Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime2");
            Property(p => p.ModifiedOn).HasColumnType("datetime2");

            //Foreign Keys
            HasRequired(p => p.Account).WithMany(i => i.ItemTags).HasForeignKey(f => f.AccountId).WillCascadeOnDelete(true);
            HasRequired(p => p.Item).WithMany(i => i.ItemTags).HasForeignKey(f => f.ItemID).WillCascadeOnDelete(false);
            HasRequired(p => p.Tag).WithMany(i => i.ItemTags).HasForeignKey(f => f.TagID).WillCascadeOnDelete(true);
            //HasRequired(p => p.User).WithMany(i => i.ItemTags).HasForeignKey(f => f.CreatedBy).WillCascadeOnDelete(false);
            //HasRequired(p => p.User).WithMany(i => i.ItemTags).HasForeignKey(f => f.ModifiedBy).WillCascadeOnDelete(false);
        }
    }
}
