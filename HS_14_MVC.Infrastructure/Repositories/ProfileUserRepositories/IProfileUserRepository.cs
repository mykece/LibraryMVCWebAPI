using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.ProfileUserRepositories
{
    public interface IProfileUserRepository: IAsyncRepository, IAsyncInsertableRepository<AppUser>, IAsyncFindableRepository<AppUser>,
        IAsyncQueryableRepository<AppUser>, IAsyncUpdatableRepository<AppUser>, IAsyncDeletableRepository<AppUser>, IAsyncTransactionRepository
    {
        Task<AppUser?> GetByIdentityId(string identityId);
    }
}
