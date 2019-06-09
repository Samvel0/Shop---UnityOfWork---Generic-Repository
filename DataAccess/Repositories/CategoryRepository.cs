using DataAccess.Context;
using DataAccess.DbTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category, DataContext>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
            
        }
    }
}
