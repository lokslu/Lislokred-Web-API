using System;
using System.Collections.Generic;

namespace Lislokred_Web_API.Models
{
    public class MovieFullInformationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UrlData { get; set; }

        public bool? State { get; set; }
        public int? Rate { get; set; }

        public IEnumerable<GenreModel> Genres{ get; set; }

    }
}
