using DataAccess.Context;
using DataAccess.Repositories;
using ServiceContracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;


namespace Services.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {

        private readonly DataContext _dbContext;        
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWorkService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.ContainsKey(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public int Commit()
        {
            _dbContext.SaveChanges();

            return 1;
        }
    }
}
