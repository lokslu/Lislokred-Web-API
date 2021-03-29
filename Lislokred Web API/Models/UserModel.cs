using Lislokred_Web_API.Models.Entitys;
using System.Collections.Generic;

namespace Lislokred_Web_API.Models
{
    public class UserModel
    {
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        
        //не нужно подтягиваеться отдельным запросом
        //public List<GenreModel> FavoriteGenres { get; set; }
    }
}
