using Lislokred_Web_API.Models.Entitys;
using System.Collections.Generic;
using AutoMapper;
using Lislokred_Web_API.Models;

namespace Lislokred_Web_API.Controllers
{
    internal class GenreRepository
    {
        private readonly ApplicationContext db;
        public GenreRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public IEnumerable<Genre> Get()
        {
           return db.Genres;
        }

    }
}