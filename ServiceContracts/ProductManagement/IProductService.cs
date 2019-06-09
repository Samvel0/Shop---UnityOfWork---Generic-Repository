using DataAccess.DbTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.ProductManagement
{
    public interface IProductService
    {
        void AddProduct(Product model);
        IEnumerable<Product> GetAllProducts();
        void DeleteProduct(int id);
        void EditProduct(Product model);
        Product GetProductId(int id);
        IEnumerable<Category> GetCategoryList();
    }
}
