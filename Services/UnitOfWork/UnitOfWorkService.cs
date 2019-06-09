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
        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        private DataContext _dbContext;

        public UnitOfWorkService(DataContext dbContext,
                                 ICategoryRepository categoryRepository,
                                 IProductRepository productRepository)
        {
            _dbContext = dbContext;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }

        public int Commit()
        {
            _dbContext.SaveChanges();

            return 1;
        }
    }
}
