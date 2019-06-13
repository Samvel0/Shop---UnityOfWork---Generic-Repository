using DataAccess.Context;
using DataAccess.DbTypes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
