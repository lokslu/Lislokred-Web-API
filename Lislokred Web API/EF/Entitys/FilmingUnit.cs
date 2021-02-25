using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lislokred_Web_API.Models.Entitys
{
    public class FilmingUnit
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Ratio> Ratios { get; set; } = new List<Ratio>();

        public List<ImageUnit> ImagesUnit { get; set; } = new List<ImageUnit>();
    }
}
