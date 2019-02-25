using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GNW.ILS.DAL.Contract;

namespace GNW.ILS.DAL.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
           return _dbContext.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            //DbEntityEntry<T> dbEntityEntry = _dataContext.Entry(entity);
            //dbEntityEntry.Property(a=>a.Email)
            // _dbContext.Set<T>().Attach(entity);
            //var dbEntry=_dataContext.Entry(entity);
            // dbEntry.Property(x=>x.) = true;
            // //.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbContext.Set<T>().Where<T>(where).AsEnumerable();
            foreach (T obj in objects) _dbContext.Set<T>().Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).FirstOrDefault<T>();
        }

        //public virtual IEnumerable<T> GetAll()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}

        //public IQueryable<T> GetAll()
        //{
        //    return _dbContext.Set<T>();
        //}

        public Task<List<T>> GetAllAsync()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).ToList();
        }
    }
}
