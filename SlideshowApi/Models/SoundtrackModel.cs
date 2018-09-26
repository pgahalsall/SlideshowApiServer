using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideshowApi.Models
{
    public class SoundtrackModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Musician { get; set; }
        public string Song { get; set; }
        public decimal? Duration { get; set; }
    }
}