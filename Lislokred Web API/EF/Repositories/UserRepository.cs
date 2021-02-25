using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lislokred_Web_API.Models.Entitys
{//Мынипуляцыи над users 
    public class UserRepository 
    {
        private readonly ApplicationContext db;

        public UserRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public User FindById(Guid id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> Get()
        {
            return db.Users;
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return from item in db.Users where predicate(item) select item;
        }

        public bool Remove(User item)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == item.Id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool OriginalityCheckNickname(string Nickname,string Email)
        {
            return !db.Users.Any(x => x.Nickname == Nickname||x.Email==Email);
        }
        public User AuthenticateUser(string email, string password)
        {
            return db.Users.FirstOrDefault(u => email == u.Email && u.Password == password);
        }
    }

}