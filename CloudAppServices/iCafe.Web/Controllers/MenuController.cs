using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCafe.Web.ViewModels;

namespace iCafe.Web.Controllers
{
    public class MenuController : BaseController
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var model = new CategoriesVM()
            {
                CategoryList = new List<Category>() { 
                    new Category() { Id = 1, Title = "Biryani", Description = "There are various forms of Hyderabadi biryani.", TotalItems=8, Discount=0.00f, ImagePath="~/Images/Menu/Categories/biryani.jpg" },
                    new Category() { Id = 2, Title = "Rotis", Description = "Roti is a flat bread originating from the Indian subcontinent.", TotalItems=10, Discount=5.00f, ImagePath="~/Images/Menu/Categories/rotis.jpg" },
                    new Category() { Id = 3, Title = "Curries", Description = "Various parts of the sub-continent have their own regional variations of curry.", TotalItems=15, Discount=3.00f, ImagePath="~/Images/Menu/Categories/curries.jpg" },
                    new Category() { Id = 4, Title = "Noodles", Description = "Noodles are made of acorn meal, wheat flour, wheat germ, and salt.", TotalItems=20, Discount=5.00f, ImagePath="~/Images/Menu/Categories/noodles.jpg" },
                    new Category() { Id = 5, Title = "Pizzas", Description = "Pizza bread is a type of sandwich that is often served open-faced.", TotalItems=16, Discount=8.00f, ImagePath="~/Images/Menu/Categories/pizza.jpg" },
                    new Category() { Id = 6, Title = "Beverages", Description = "Any one of various liquids for drinking, usually excluding water.", TotalItems=7, Discount=10.00f, ImagePath="~/Images/Menu/Categories/beverages.jpg" },
                    new Category() { Id = 7, Title = "Desserts", Description = "Dessert is a course that concludes a main meal.", TotalItems=11, Discount=15.00f, ImagePath="~/Images/Menu/Categories/desserts.jpg" },
                },
                DefaultImagePath = "/Images/sorry-image-not-available.png"
            }; 
            return View(model);
        }

        public ActionResult Tags()
        {
            var model = new TagsVM()
            {
                Tags = new List<Tag>()
                {
                    new Tag(){ ID = 1, Title = "Veg", Description = "Vegetarain items", Discount = 14.50f, CreatedOn = DateTime.Now.AddDays(-10).Date, IsAvailable = true },
                    new Tag(){ ID = 2, Title = "Non-Veg", Description = "Non-Vegetarain items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-10), IsAvailable = true },
                    new Tag(){ ID = 3, Title = "Chicken", Description = "Chicken Items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-9), IsAvailable = false },
                    new Tag(){ ID = 4, Title = "Sea Food", Description = "items like fish, pawns", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-9), IsAvailable = true },
                    new Tag(){ ID = 5, Title = "fish", Description = "fish items", Discount = 10.00f, CreatedOn = DateTime.Now.Date.AddDays(-8), IsAvailable = false },
                    new Tag(){ ID = 6, Title = "Dosa", Description = "Dosa items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-8), IsAvailable = true },
                    new Tag(){ ID = 7, Title = "Paneer", Description = "Paneer items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-5), IsAvailable = true },
                    new Tag(){ ID = 8, Title = "Chinese", Description = "Chinese dishes", Discount = 5.50f, CreatedOn = DateTime.Now.Date.AddDays(-5), IsAvailable = false },
                    new Tag(){ ID = 9, Title = "South Indain", Description = "South Indain items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-5), IsAvailable = true },
                    new Tag(){ ID = 10, Title = "North Indain", Description = "North Indain", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-5), IsAvailable = false },
                    new Tag(){ ID = 11, Title = "egg", Description = "eggetarain items", Discount = 0.00f, CreatedOn = DateTime.Now.Date.AddDays(-5), IsAvailable = true }
                
                }
            };

            return View(model);
        }

        public ActionResult Items()
        {
            ItemsVM items = new ItemsVM() {
                Categories = new List<Category>() { 
                    new Category() { Id = 1, Title = "Soups", Description = "There are various forms of soups available.", TotalItems=8, Discount=0.00f, ImagePath="~/Images/Menu/CategoriesVM/biryani.jpg" },
                    new Category() { Id = 2, Title = "Rotis", Description = "Roti is a flat bread originating from the Indian subcontinent.", TotalItems=10, Discount=5.00f, ImagePath="~/Images/Menu/CategoriesVM/rotis.jpg" },
                    new Category() { Id = 3, Title = "Curries", Description = "Various parts of the sub-continent have their own regional variations of curry.", TotalItems=15, Discount=3.00f, ImagePath="~/Images/Menu/CategoriesVM/curries.jpg" },
                    new Category() { Id = 4, Title = "Noodles", Description = "Noodles are made of acorn meal, wheat flour, wheat germ, and salt.", TotalItems=20, Discount=5.00f, ImagePath="~/Images/Menu/CategoriesVM/noodles.jpg" },
                    new Category() { Id = 5, Title = "Pizzas", Description = "Pizza bread is a type of sandwich that is often served open-faced.", TotalItems=16, Discount=8.00f, ImagePath="~/Images/Menu/CategoriesVM/pizza.jpg" },
                    new Category() { Id = 6, Title = "Beverages", Description = "Any one of various liquids for drinking, usually excluding water.", TotalItems=7, Discount=10.00f, ImagePath="~/Images/Menu/CategoriesVM/beverages.jpg" },
                    new Category() { Id = 7, Title = "Desserts", Description = "Dessert is a course that concludes a main meal.", TotalItems=11, Discount=15.00f, ImagePath="~/Images/Menu/CategoriesVM/desserts.jpg" },
                }, 
                Items = new List<Item>(){
                    new Item() { ID = 1, CategoryID = 1, Name = "Albondigas",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/albondigas-soup.png"},
                    new Item() { ID = 2, CategoryID = 1, Name = "Avgolemono",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/Avgolemono.png"},
                    new Item() { ID = 3, CategoryID = 1, Name = "Borscht",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/Borscht-soup.png"},
                    new Item() { ID = 4, CategoryID = 1, Name = "Bouillabaisse",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/Bouillabaisse-soup.png"},
                    new Item() { ID = 5, CategoryID = 1, Name = "Broccoli Cheese",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/BroccoliCheese-soup.png"},
                    new Item() { ID = 6, CategoryID = 1, Name = "Caldo verde",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/CaldoVerde-soup.png"},
                    new Item() { ID = 7, CategoryID = 1, Name = "Callaloo",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/Callaloo-soup.png"},
                    new Item() { ID = 8, CategoryID = 1, Name = "Cock-a-leekie",Price = 250.00f, Description = "Soup Item", ImagePath = "~/Images/Menu/Items/Soups/default-soup.png"}
                },
                
                DefaultActiveCategory = 1,
               
                DefaultImagePath = "~/Images/Menu/Items/Soups/albondigas-soup.png"
            };
            return View(items);
        }
	}
}