using System;

namespace Lislokred_Web_API.Models.Entitys
{
    public class UserToGenre
    {

        public int GanreId { get; set; }
        public Genre Ganre { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
