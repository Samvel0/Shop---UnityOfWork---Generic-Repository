using DataAccess.Repositories;

namespace ServiceContracts.UnitOfWork
{
    public interface IUnitOfWorkService
    { 
        ICategoryRepository CategoryRepository { get; }

        IProductRepository ProductRepository { get; }

        int Commit();
    }
}
