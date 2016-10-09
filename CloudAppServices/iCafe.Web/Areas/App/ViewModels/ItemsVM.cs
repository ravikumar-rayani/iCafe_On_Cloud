using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCafe.Web.Areas.App.ViewModels
{
    public class ItemsVM
    {
        public List<Category> Categories { get; set; }

        public List<Item> Items { get; set; }

        public int DefaultActiveCategory { get; set; }

        public string DefaultImagePath { get; set; }
    }

    public class Item
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CategoryID { get; set; }

        public float Price { get; set; }

        public List<string> Tags { get; set; }

        public bool IsAvailable { get; set; }

        public float Discount { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}