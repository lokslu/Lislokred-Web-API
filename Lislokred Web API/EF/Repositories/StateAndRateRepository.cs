using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lislokred_Web_API.Models.Entitys
{//Мынипуляцыи над Movies 
 //1. поиск по id или по Email
 //2. создание или добавление
 //3. удаление по id или по Email
 //4. изменение

    class StateAndRateRepository
    {
        private readonly ApplicationContext db;
        public StateAndRateRepository(ApplicationContext context)
        {
            db = context;
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