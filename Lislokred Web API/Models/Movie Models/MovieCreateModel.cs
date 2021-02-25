using System;
using System.Collections.Generic;

namespace Lislokred_Web_API.Models
{
    public class MovieCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Genre{ get; set; }
        
        //Id, Role in movie
        public Dictionary<Guid,string> FilmUnit{ get; set; }

    }
}
