using System;

namespace Lislokred_Web_API.Models
{
    public class StateAndRateModel
    {
        public Guid MovieId { get; set; }
        public bool State { get; set; }
        public int? Rate { get; set; }
    }
}