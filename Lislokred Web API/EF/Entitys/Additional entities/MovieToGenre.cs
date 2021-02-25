using System;

namespace Lislokred_Web_API.Models.Entitys
{
    public class MovieToGenre
    {
        public int GanreId { get; set; }
        public Genre Ganre { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}