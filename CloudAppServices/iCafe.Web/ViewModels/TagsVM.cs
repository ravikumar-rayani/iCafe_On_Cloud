using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iCafe.Web.ViewModels
{
    public class TagsVM
    {
        public List<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Discount { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsAvailable { get; set; }
    }
}