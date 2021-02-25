using System;

namespace Lislokred_Web_API.Models.Entitys
{
    public class StateAndRate
    {

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool State { get; set; }
        public int? Rate { get; set; }
    }
}
