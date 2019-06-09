using DataAccess.DbTypes;
using ServiceContracts.ProductManagement;
using ServiceContracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

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
            _unitOfWorkService.ProductRepository.Insert(model);
            _unitOfWorkService.Commit();
        }

        public void DeleteProduct(int id)
        {
            _unitOfWorkService.ProductRepository.DeleteById(id);
            _unitOfWorkService.Commit();
        }

        public void EditProduct(Product model)
        {
            _unitOfWorkService.ProductRepository.Update(model);
            _unitOfWorkService.Commit();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWorkService.ProductRepository.GetAll();
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _unitOfWorkService.CategoryRepository.GetAll();
        }

        public Product GetProductId(int id)
        {
            return _unitOfWorkService.ProductRepository.GetById(id);
        }
    }
}
