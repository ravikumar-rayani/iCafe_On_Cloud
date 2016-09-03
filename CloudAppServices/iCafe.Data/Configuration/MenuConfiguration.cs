using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCafe.Model.Models;

namespace iCafe.Data.Configuration
{
    class MenuConfiguration: EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            ToTable("Menus");
            Property(c => c.Name).HasMaxLength(50);
        }
    }
}
