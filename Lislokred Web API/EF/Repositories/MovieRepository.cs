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
                newMovie.Ratios.Add(new Ratio { MovieId = newMovie.Id, FilmUnitId = i.Key, Role = i.Value, Movie = newMovie });
                // newMovie.FilmСrew.Add(db.FilmingUnits.FirstOrDefault(x => x.Id == i.Key));//Работает

            }

            db.SaveChanges();
        }

        public void Create(Movie item)
        {
            db.Movies.Add(item);
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
        public IEnumerable<MovieModel> GetSeenMovie(Guid UserId)
        {

            var Relation = db.StateAndRate.Where(x => x.UserId == UserId && x.State == true);

            //List<MovieModel> Movies2 = db.Movies.Where(x=>Relation.Any(y=>y.MovieId==x.Id))
            //    .Select(v=> new MovieModel { 
            //     Id=v.Id,
            //    Name=v.Name,
            //    Rate=v.});

            IEnumerable<MovieModel> Movies = db.Movies.Join(Relation,
                                    x => x.Id,
                                    y => y.MovieId,
                                    (x, y) => new MovieModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Rate = y.Rate,
                                        State = y.State,
                                        UrlData = "Pictures/Movies/" + db.ImageMovies.FirstOrDefault(i => i.MovieId == x.Id && i.IsMain == true).UrlData
                                    }); ;


            return Movies;
            //  var RateAndState2 = db.Movies.Include(c => c.StateAndRate.Where(v=>v.UserId==UserId)).FirstOrDefault(x => x.Id == MovieId).StateAndRate[0];
        }
        public IEnumerable<MovieModel> GetAllMovie(string UserId = null)
        {


            IEnumerable<MovieModel> movies = db.Movies.Select(x => new MovieModel()
            {
                Id = x.Id,
                Name = x.Name,
                UrlData = "Pictures/Movies/" + db.ImageMovies.FirstOrDefault(i => i.MovieId == x.Id && i.IsMain == true).UrlData
            }).ToList();

            if (UserId != null)
            {
                DataForUser(UserId, ref movies);
            }
            return movies;
        }

        public IEnumerable<MovieModel> GetToBeSeenMovie(Guid UserId)
        {
            var Relation = db.StateAndRate.Where(x => x.UserId == UserId && x.State == false);


            IEnumerable<MovieModel> Movies = db.Movies.Join(Relation,
                                   x => x.Id,
                                   y => y.MovieId,
                                   (x, y) => new MovieModel
                                   {
                                       Id = x.Id,
                                       Name = x.Name,
                                       Rate = y.Rate,
                                       State = y.State,
                                       UrlData = "Pictures/Movies/" + db.ImageMovies.FirstOrDefault(i => i.MovieId == x.Id && i.IsMain == true).UrlData
                                   }); ;


            return Movies;
        }


        public MovieModel GetMovieModelById(Guid MovieId, string UserId = null)
        {

            var movie = db.Movies.FirstOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                return null;
            }

            var MainImage = db.ImageMovies.FirstOrDefault(x => x.IsMain == true && x.MovieId == MovieId);

            MovieModel result = new MovieModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                UrlData = "Pictures/Movies/" + MainImage.UrlData

            };
            if (UserId != null)
            {
                var RateAndState = db.StateAndRate.FirstOrDefault(x => x.MovieId == MovieId && x.UserId == Guid.Parse(UserId));
                result.State = RateAndState?.State;
                result.Rate = RateAndState?.Rate;
            }
            return result;
            //  var RateAndState2 = db.Movies.Include(c => c.StateAndRate.Where(v=>v.UserId==UserId)).FirstOrDefault(x => x.Id == MovieId).StateAndRate[0];
        }
        public MovieFullInformationModel GetMovieFullinfModelById(Guid MovieId, string UserId = null)
        {

            var movie = db.Movies.FirstOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                return null;
            }

            var MainImage = db.ImageMovies.FirstOrDefault(x => x.IsMain == true && x.MovieId == MovieId);


            MovieFullInformationModel result = new MovieFullInformationModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                UrlData = "Pictures/Movies/" + MainImage.UrlData

            };

            result.Genres = db.MovieToGenre.Where(x => x.MovieId == MovieId).Select(s => new GenreModel()
            {
                Id = s.GanreId,
                Data = db.Genres.FirstOrDefault(g => g.Id == s.GanreId).Data
            });

            if (UserId != null)
            {
                var RateAndState = db.StateAndRate.FirstOrDefault(x => x.MovieId == MovieId && x.UserId == Guid.Parse(UserId));
                result.State = RateAndState?.State;
                result.Rate = RateAndState?.Rate;
            }
            return result;
            //  var RateAndState2 = db.Movies.Include(c => c.StateAndRate.Where(v=>v.UserId==UserId)).FirstOrDefault(x => x.Id == MovieId).StateAndRate[0];
        }
        public IEnumerable<MovieModel> Serch(string MovieName, string UserId = null)
        {
            IEnumerable<MovieModel> movies = db.Movies.Where(x => x.Name.Contains(MovieName)).Select(s => new MovieModel()
            {
                Id = s.Id,
                Name = s.Name,
                UrlData = "Pictures/Movies/" + db.ImageMovies.FirstOrDefault(i => i.MovieId == s.Id && i.IsMain == true).UrlData
            }).ToList();
            if (UserId != null)
            {
                DataForUser(UserId, ref movies);
            }
            return movies;
        }


        private void DataForUser(string UserId, ref IEnumerable<MovieModel> movies)
        {
            var StateAndRate = db.StateAndRate.Where(x => x.UserId == Guid.Parse(UserId));
            movies = movies.Select(x => new MovieModel
            {
                Id = x.Id,
                Name = x.Name,
                UrlData = x.UrlData,
                State = StateAndRate.FirstOrDefault(w => w.MovieId == x.Id && w.UserId == Guid.Parse(UserId))?.State,
                Rate = StateAndRate.FirstOrDefault(w => w.MovieId == x.Id && w.UserId == Guid.Parse(UserId))?.Rate

            });


        }
    }
}