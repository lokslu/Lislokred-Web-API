using System;
using System.Collections.Generic;

namespace Lislokred_Web_API.Models.Entitys
{//Мынипуляцыи над Movies 
    public interface IRepository<T> where T : class
    {
        void Create(T item);//добавление(создание)
        T FindByPredicate(Func<T, bool> predicate);//поиск ОДНОГО элемента по предикату
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        bool Remove(T item);//удаление
        bool Update(T item);//обновление
    }
}