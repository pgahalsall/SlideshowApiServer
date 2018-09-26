using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlideshowApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Url { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}