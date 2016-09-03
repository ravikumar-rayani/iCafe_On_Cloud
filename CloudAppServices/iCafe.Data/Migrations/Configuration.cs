namespace iCafe.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using iCafe.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<iCafe.Data.iCafeEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iCafe.Data.iCafeEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.ItemCategories.AddOrUpdate(
                    p => p.Id,
                    new ItemCategory() { Id = 1, Name = "Category1", IsAvailable = true, CreatedOn = DateTime.Now },
                    new ItemCategory() { Id = 2, Name = "Category2", IsAvailable = false, CreatedOn = DateTime.Now },
                    new ItemCategory() { Id = 3, Name = "Category3", IsAvailable = true, CreatedOn = DateTime.Now }
                );
        }
    }
}
