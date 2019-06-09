using DataAccess.DbTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.CategoryManagement
{
    public interface ICategoryService
    {
        void AddCategory(Category model);
        IEnumerable<Category> GetAllCategories();
        void DeleteCategory(int id);
        void EditCategory(Category model);
        Category GetCategoryById(int id);
    }
}
