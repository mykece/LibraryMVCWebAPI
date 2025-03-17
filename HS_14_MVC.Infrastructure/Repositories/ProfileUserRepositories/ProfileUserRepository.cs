using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.AppContext;
using HS_14_MVC.Infrastructure.DataAccess.EntityFramework;
using HS_14_MVC.Infrastructure.Repositories.AdminRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.ProfileUserRepositories
{
    public class ProfileUserRepository : EFBaseRepository<AppUser>, IProfileUserRepository
    {
        public ProfileUserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<AppUser?> GetByIdentityId(string identityId)
        {
            return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
        }
    }
}
