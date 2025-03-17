using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.BookRepositories
{
    public interface IBookRepository : IAsyncRepository, IAsyncInsertableRepository<Book>, IAsyncFindableRepository<Book>,
        IAsyncQueryableRepository<Book>, IAsyncUpdatableRepository<Book>, IAsyncDeletableRepository<Book>
    {
    }
}
