﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GNW.ILS.DAL.Contract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);
        //IQueryable<T> GetById(int id);

        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        //IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        //IQueryable<T> GetAll();

        Task<List<T>> GetAllAsync();


        //void Insert(T entity);
        //void Delete(T entity);
        //IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        //IQueryable<T> GetAll();
        //T GetById(int id);
    }
}