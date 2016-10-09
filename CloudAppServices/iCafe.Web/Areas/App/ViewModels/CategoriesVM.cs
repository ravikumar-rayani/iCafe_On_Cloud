using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCafe.Web.Areas.App.ViewModels
{
    public class CategoriesVM
    {
        public List<Category> CategoryList { get; set; }

        public string DefaultImagePath { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int TotalItems { get; set; }

        public float Discount { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}