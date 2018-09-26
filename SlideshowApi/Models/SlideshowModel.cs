using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideshowApi.Models
{
    public class SlideshowModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public DateTime? LastUpdated { get; set; }

        public IEnumerable<SlideModel> Slides { get; set; }
       // public IEnumerable<SlideModel> Slides { get; set; }
    }
}