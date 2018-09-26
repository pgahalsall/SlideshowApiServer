using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideshowApi.Models
{
    public class SlideModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string SlideName { get; set; }
        //public IEnumerable<MeasureModel> Measures { get; set; }
    }
}