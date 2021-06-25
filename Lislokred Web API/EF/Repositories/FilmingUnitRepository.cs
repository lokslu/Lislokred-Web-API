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

        public static Comparison<Ratio> comparison = delegate (Ratio x, Ratio y)
          {
              if (x.Orderig > y.Orderig)
              {
                  return 1;
              }
              if (y.Orderig > x.Orderig)
              {
                  return -1;
              }
              return 0;
          };

        public FilmingUnitRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public IEnumerable<FilmingUnitModel> GetByMovieId(Guid MovieId,string domen)
        {
            var RatioUnits = db.Ratio.Where(x => x.MovieId == MovieId).ToList();

            RatioUnits.Sort(comparison);

            var Units= RatioUnits.Join(db.FilmingUnits, y => y.FilmUnitId, g => g.Id,
                   (y, g) => new FilmingUnitModel()
                   {
                       Id = g.Id,
                       FirstName = g.FirstName,
                       LastName = g.LastName,

                   }).ToList();

            for (int i = 0; i < Units.Count; i++)
            {
                var image = db.ImageUnit.FirstOrDefault(ix => ix.UnitId == Units[i].Id && ix.IsMain == true);

                if (image?.UrlData == null)
                {
                    Units[i].UrlData = domen + "/Pictures/FilmUnits/maket.jpg";
                    continue;
                }
                if (image.IsAnotherSource==true)
                {
                    Units[i].UrlData = image.UrlData;
                    continue;
                }
                else
                {
                    Units[i].UrlData = domen + "/Pictures/FilmUnits/" + image.UrlData;
                }
            }
            return Units;


        }
    }
}