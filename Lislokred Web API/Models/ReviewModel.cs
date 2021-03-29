using System;

namespace Lislokred_Web_API.Models
{
    public class ReviewModel
    {
        public Guid IdUser { get; set; }
        public int Rate { get; set; }
        public string Nickname { get; set; }
        public string UrlImage { get; set; }


    }
}