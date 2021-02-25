using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lislokred_Web_API.Models.Entitys
{//Мынипуляцыи над Movies 
    class MovieRepository 
    {
        private readonly ApplicationContext db;

        public MovieRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public void Create(MovieCreateModel item)
        {
            Movie newMovie = new Movie()
            {
                Description = item.Description,
                Name = item.Name,
            };
            /*не работает */
            //newMovie.Ganres = db.Genres.Join(item.Genre,
            //                            c => c.Id,
            //                            f => f,
            //                            (Q1,Q2) => Q1).ToList();

            /*работат но в силу переконфигурации модели не актуален*/
            //newMovie.MovieToGenre = db.Genres.Where(t => item.Genre.Contains(t.Id)).ToList();

            db.Entry(newMovie).State = EntityState.Added;
            //или 
            //db.Movies.Add(newMovie);
            //но важно это зделать до присврение внешних ключей для ссылания на другие сущьности ибо после етого начинаеться отслежывание которое фиксируеться сохранением в конце
            foreach (var i in item.Genre)
            {
                newMovie.MovieToGenre.Add(new MovieToGenre { MovieId = newMovie.Id, GanreId = i });
            }
            foreach (var i in item.FilmUnit)
            {
                newMovie.Ratios.Add(new Ratio { MovieId = newMovie.Id, FilmUnitId = i.Key, Role = i.Value,Movie= newMovie });
               // newMovie.FilmСrew.Add(db.FilmingUnits.FirstOrDefault(x => x.Id == i.Key));//Работает

            }

            db.SaveChanges();
        }

      

        public Movie FindById(Guid id)
        {
            return db.Movies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> Get()
        {
            return db.Movies;
        }

        public IEnumerable<Movie> Get(Func<Movie, bool> predicate)
        {
            return from item in db.Movies where predicate(item) select item;
        }

        public bool Remove(Guid Id)
        {
            var Movie = db.Movies.FirstOrDefault(x => x.Id == Id);
            if (Movie != null)
            {
                db.Movies.Remove(Movie);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Movie item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public MovieModel GetMovieModelById(Guid MovieId, Guid UserId)
        {
            var movie=db.Movies.FirstOrDefault(x => x.Id == MovieId);

            var MainImage = db.ImageMovies.FirstOrDefault(x => x.IsMain == true&& x.MovieId== MovieId);

            var RateAndState = db.StateAndRate.FirstOrDefault(x=>x.MovieId== MovieId&&x.UserId==UserId);
          //  var RateAndState2 = db.Movies.Include(c => c.StateAndRate.Where(v=>v.UserId==UserId)).FirstOrDefault(x => x.Id == MovieId).StateAndRate[0];
            return new MovieModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                UrlData = MainImage.UrlData,
                State = RateAndState.State,
                Rate = RateAndState?.Rate,
            };
        }

        public void Create(Movie item)
        {
            db.Movies.Add(item);
            db.SaveChanges();
        }
    }
}   