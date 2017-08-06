using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Movie.Models;
using System.Data.Entity;

namespace Movie.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;
        protected movieEntities db;
        public Repository(DbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
            db = (movieEntities)dataContext;
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        #endregion
    }
}