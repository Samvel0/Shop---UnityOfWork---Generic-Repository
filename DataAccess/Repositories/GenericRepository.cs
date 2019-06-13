using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
                                                                        
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Insert(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Add(entity);
            }
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Update(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
        }
    }
}
