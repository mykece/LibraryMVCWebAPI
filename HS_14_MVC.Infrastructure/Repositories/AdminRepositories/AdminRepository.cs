using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Infrastructure.AppContext;
using HS_14_MVC.Infrastructure.DataAccess.EntityFramework;
using HS_14_MVC.Infrastructure.Repositories.AuthorRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Repositories.AdminRepositories
{
    internal class AdminRepository : EFBaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Admin?> GetByIdentityId(string identityId)
        {
            return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
        }
    }
}
