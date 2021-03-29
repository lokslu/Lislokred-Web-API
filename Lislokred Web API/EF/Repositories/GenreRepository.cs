using Lislokred_Web_API.Models.Entitys;
using System.Collections.Generic;
using AutoMapper;
using Lislokred_Web_API.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<GenreModel> GetByMovieId(Guid MovieId)
        {
            return db.MovieToGenre.Where(x => x.MovieId == MovieId).Select(s => new GenreModel()
            {
                Id = s.GanreId,
                Data = db.Genres.FirstOrDefault(g => g.Id == s.GanreId).Data
            });

            

        }

    }
}