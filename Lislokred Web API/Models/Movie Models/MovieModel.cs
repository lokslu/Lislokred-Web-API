using System;

namespace Lislokred_Web_API.Models
{
    public class MovieModel
    {  
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string UrlData { get; set; }

        public bool? State { get; set; }
        public int? Rate { get; set; }

    }
}
