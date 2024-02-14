using HasanBozkusCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HasanBozkusCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DBCvEntities db = new DBCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }

        public void TDelete(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T t)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}