using DataAccess.DbTypes;
using ServiceContracts.CategoryManagement;
using ServiceContracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CategoryManagement
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public CategoryService(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        public void AddCategory(Category model)
        {
            _unitOfWorkService.CategoryRepository.Insert(model);
            _unitOfWorkService.Commit();
        }

        public void DeleteCategory(int id)
        {
            _unitOfWorkService.CategoryRepository.DeleteById(id);
            _unitOfWorkService.Commit();
        }

        public void EditCategory(Category model)
        {
            _unitOfWorkService.CategoryRepository.Update(model);
            _unitOfWorkService.Commit();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWorkService.CategoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWorkService.CategoryRepository.GetById(id);
        }
    }
}
