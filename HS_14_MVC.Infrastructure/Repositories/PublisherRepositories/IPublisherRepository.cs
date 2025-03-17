using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.PublisherRepositories;

public interface IPublisherRepository : IAsyncRepository, IAsyncInsertableRepository<Publisher>, IAsyncFindableRepository<Publisher>,
    IAsyncQueryableRepository<Publisher>, IAsyncUpdatableRepository<Publisher>,IAsyncDeletableRepository<Publisher>
{
    //Task DeleteAsync(Publisher deletingCategory);

}
