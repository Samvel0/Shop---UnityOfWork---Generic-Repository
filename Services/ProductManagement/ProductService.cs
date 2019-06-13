using DataAccess.DbTypes;
using ServiceContracts.ProductManagement;
using ServiceContracts.UnitOfWork;
using System.Collections.Generic;

namespace Services.ProductManagement
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public ProductService(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        public void AddProduct(Product model)
        {
            _unitOfWorkService.Repository<Product>().Insert(model);
            _unitOfWorkService.Commit();
        }

        public void DeleteProduct(int id)
        {
            _unitOfWorkService.Repository<Product>().DeleteById(id);
            _unitOfWorkService.Commit();
        }

        public void EditProduct(Product model)
        {
            _unitOfWorkService.Repository<Product>().Update(model);
            _unitOfWorkService.Commit();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWorkService.Repository<Product>().GetAll();
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _unitOfWorkService.Repository<Category>().GetAll();
        }

        public Product GetProductId(int id)
        {
            return _unitOfWorkService.Repository<Product>().GetById(id);
        }
    }
}
