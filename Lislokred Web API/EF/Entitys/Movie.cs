using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lislokred_Web_API.Models.Entitys
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImdbId{ get; set; }
        public double ImdbAverageRating { get; set; }
        public int ImdbNumVotes { get; set; }

        public List<Ratio> Ratios { get; set; } = new List<Ratio>();

        public List<StateAndRate> StateAndRate { get; set; } = new List<StateAndRate>();
     
        public List<MovieToGenre> MovieToGenre { get; set; } = new List<MovieToGenre>();

        public List<ImageMovie> ImageMovies { get; set; } = new List<ImageMovie>();


    }
}
