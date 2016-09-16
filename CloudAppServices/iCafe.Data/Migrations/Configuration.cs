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
            context.AccountTypes.AddOrUpdate(
                p => p.Id,
                new AccountType { Id = 1, Name = "Trail", IsActive = true, Description = "Trail Version" }
                );

            context.Accounts.AddOrUpdate(
                p => p.Id,
                new Account { Id = 1, Name = "Trail", IsActive = true, AccoutTypeId = 1, CompanyName = "iCafe", EmailId = "trail@trail.com", EndDate = DateTime.Now.AddMonths(1), IsMultiBranchesAllowed = true, MaxBranches = 1 }
                );

            context.Branches.AddOrUpdate(
                p => p.Id,
                new Branch { Id = 1, Name = "HeadQuater", AccountId = 1 }
                );

            context.ItemCategories.AddOrUpdate(
                p => p.Id,
                new ItemCategory { Id = 1, Name = "Roti", AccountId = 1, Description = "Rotis" },
                new ItemCategory { Id = 2, Name = "Curries", AccountId = 1, Description = "Curries" }
            );

            context.Items.AddOrUpdate(
                p => p.Id,
                new Item { Id = 1, Name = "Naan", AccountId = 1, ItemCategoryId = 1, Price = 40, SpicyLevel = 3, Ingrediants = "", Discount = 0, SmallImage = "small image", FullImage = "full image" },
                new Item { Id = 1, Name = "Pulka", AccountId = 1, ItemCategoryId = 1, Price = 50, SpicyLevel = 2, Ingrediants = "", Discount = 0, SmallImage = "small image", FullImage = "full image" },
                new Item { Id = 1, Name = "Paneer Masala", AccountId = 1, ItemCategoryId = 2, Price = 210, SpicyLevel = 1, Ingrediants = "", Discount = 1, SmallImage = "small image", FullImage = "full image" },
                new Item { Id = 1, Name = "Chicken Masala", AccountId = 1, ItemCategoryId = 2, Price = 250, SpicyLevel = 5, Ingrediants = "", Discount = 1, SmallImage = "small image", FullImage = "full image" }
                );
        }
    }
}
