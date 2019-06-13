using DataAccess.DbTypes;
using ServiceContracts.CategoryManagement;
using ServiceContracts.UnitOfWork;
using System.Collections.Generic;

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
            _unitOfWorkService.Repository<Category>().Insert(model);
            _unitOfWorkService.Commit();
        }

        public void DeleteCategory(int id)
        {
            _unitOfWorkService.Repository<Category>().DeleteById(id);
            _unitOfWorkService.Commit();
        }

        public void EditCategory(Category model)
        {
            _unitOfWorkService.Repository<Category>().Update(model);
            _unitOfWorkService.Commit();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWorkService.Repository<Category>().GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWorkService.Repository<Category>().GetById(id);
        }
    }
}
