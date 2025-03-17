using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.AuthorRepositories
{
    public interface IAuthorRepository: IAsyncRepository, IAsyncInsertableRepository<Author>, IAsyncFindableRepository<Author>,
        IAsyncQueryableRepository<Author>, IAsyncUpdatableRepository<Author>, IAsyncDeletableRepository<Author>
    {
       // Task DeleteAsync(Author deletingCategory);
    }
}
