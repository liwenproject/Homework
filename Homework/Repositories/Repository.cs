using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;

namespace Homework.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public DbSet<T> _ObjectSet;
        public DbSet<T> ObjectSet
        {
            get
            {
                if (_ObjectSet == null)
                {
                    _ObjectSet = UnitOfWork.Context.Set<T>();
                }
                return _ObjectSet;
            }
        }       

        public void Commit()
        {
            UnitOfWork.save();
        }

        public void Create(T entity)
        {
            ObjectSet.Add(entity);
        }


        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.SingleOrDefault(filter);
        }

        public IQueryable<T> LookupAll()
        {
            return ObjectSet;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.Where(filter);
        }

        public void Remove(T entity)
        {
            ObjectSet.Remove(entity);
        }
    }
}