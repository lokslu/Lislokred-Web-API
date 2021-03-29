using Lislokred_Web_API.Models;
using Lislokred_Web_API.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lislokred_Web_API.Controllers
{
    internal class FilmingUnitRepository
    {
        private readonly ApplicationContext db;
        public FilmingUnitRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public IEnumerable<FilmingUnitModel> GetByMovieId(Guid MovieId)
        {
            return db.Ratio.Where(x => x.MovieId == MovieId)
                            .Join(db.FilmingUnits, y => y.FilmUnitId, g => g.Id,
                            (y, g) => new FilmingUnitModel()
                            {
                                Id = g.Id,
                                FirstName = g.FirstName,
                                LastName = g.LastName,
                                UrlData = "Pictures/FilmUnits/" + db.ImageUnit.FirstOrDefault(ix => ix.UnitId == g.Id && ix.IsMain == true).UrlData

                            });


        }
    }
}