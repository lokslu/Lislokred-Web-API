using Lislokred_Web_API.Models.Entitys;
using System.Collections.Generic;

namespace Lislokred_Web_API.Models
{
    public class RegisterModel
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Gender { get; set; }
        public List<GenreModel> FavoriteGenres { get; set; }
    }
}
