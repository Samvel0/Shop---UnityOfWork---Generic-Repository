using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Insert(T entity);
        void Insert(ICollection<T> entities);
        void Delete(T entity);
        void DeleteById(int id);
        void Update(T entity);
        void Update(ICollection<T> entities);
    }
}
