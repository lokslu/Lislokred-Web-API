using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lislokred_Web_API.Models.Entitys
{

    class StateAndRateRepository
    {
        private readonly ApplicationContext db;
        public StateAndRateRepository(ApplicationContext context)
        {
            db = context;
        }

        public IEnumerable<ReviewModel> GetReviews(Guid MovieId)
        {
            return  db.StateAndRate.Where(x => x.MovieId == MovieId && x.State == true && x.Rate > 0).Select(s => new ReviewModel()
            {
                IdUser = s.UserId,
                Rate = (int)(s.Rate),
                Nickname = db.Users.FirstOrDefault(d => d.Id == s.UserId).Nickname,
                UrlImage = db.ImageUser.FirstOrDefault(d => d.UserId == s.UserId && d.IsMain == true).UrlData
            }).ToList();

        }

        public bool ChangeRate(StateAndRate item)
        {
            var relation = db.StateAndRate.FirstOrDefault(x=>x.MovieId==item.MovieId&&x.UserId==item.UserId);
            if (relation !=null)
            {
                relation.Rate = item.Rate;
            db.Entry(relation).State = EntityState.Modified;
            db.SaveChanges();
            return true;
            }
            else
            {
            return false;
            }
        }
        public void Create(StateAndRate item)
        {
            db.StateAndRate.Add(item);
            db.SaveChanges();
        }

        public StateAndRate FindById(Guid MovieId, Guid UserId)
        {
            return db.StateAndRate.FirstOrDefault(x => x.MovieId == MovieId && x.UserId == UserId);
        }

        public IEnumerable<StateAndRate> Get()
        {
            return db.StateAndRate;
        }

        public IEnumerable<StateAndRate> Get(Func<StateAndRate, bool> predicate)
        {
            return from item in db.StateAndRate where predicate(item) select item;
        }

        public bool Remove(Guid MovieId, Guid UserId)
        {
            var relation = db.StateAndRate.FirstOrDefault(x => x.UserId == UserId && x.MovieId == MovieId);
            if (relation != null)
            {
                db.StateAndRate.Remove(relation);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(StateAndRate item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}