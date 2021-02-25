using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lislokred_Web_API.Models.Entitys
{
    public class ImageMovie
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlData { get; set; }
        public bool IsMain { get; set; }

        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
    public class ImageUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlData { get; set; }
        public bool IsMain { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }    

    }

    public class ImageUnit
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlData { get; set; }
        public bool IsMain { get; set; }

        public FilmingUnit Unit { get; set; }
        public Guid UnitId { get; set; }

    }

}
