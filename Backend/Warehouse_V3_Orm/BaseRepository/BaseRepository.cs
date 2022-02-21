﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warehouse_V3_Orm.BaseRepository
{
    public abstract class BaseRepository<C, T> : IBaseRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            //_entities.Entry(entity).State = EntityState.Modified;
            //_entities.Set<T>().AddOrUpdate(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
