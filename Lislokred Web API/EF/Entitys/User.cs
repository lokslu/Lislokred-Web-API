using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lislokred_Web_API.Models.Entitys
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Gender{ get; set; }
        public string Password { get; set; }

        public List<StateAndRate> StateAndRate { get; set; } = new List<StateAndRate>();

        public List<ImageUser> ImageUsers { get; set; } = new List<ImageUser>();

        public List<UserToGenre> UserToGenre { get; set; } = new List<UserToGenre>();


    }
}
