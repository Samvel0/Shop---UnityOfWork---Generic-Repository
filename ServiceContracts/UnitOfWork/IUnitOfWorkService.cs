using DataAccess.Repositories;

namespace ServiceContracts.UnitOfWork
{
    public interface IUnitOfWorkService
    { 

        IGenericRepository<T> Repository<T>() where T : class;

        int Commit();
    }
}
