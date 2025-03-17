using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.CategoryRepositories
{
    public interface ICategoryRepository : IAsyncRepository, IAsyncInsertableRepository<Category>, IAsyncFindableRepository<Category>,
        IAsyncQueryableRepository<Category>, IAsyncUpdatableRepository<Category> ,IAsyncDeletableRepository<Category>
    {
       // Task DeleteAsync(Category deletingCategory);
    }
}
