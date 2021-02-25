using System;

namespace Lislokred_Web_API.Models.Entitys
{
    public class Ratio
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid FilmUnitId { get; set; }
        public FilmingUnit FilmUnit { get; set; }

        public string Role { get; set; }

    }
}
