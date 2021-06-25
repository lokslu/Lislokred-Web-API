using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lislokred_Web_API.Models.Entitys
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }

        public List<UserToGenre> UserToGenre { get; set; } = new List<UserToGenre>();

        public List<MovieToGenre> MovieToGenre { get; set; } = new List<MovieToGenre>();
    }
}
 