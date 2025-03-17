
using HS_14_MVC.Infrastructure.AppContext;
using HS_14_MVC.Infrastructure.Repositories.AdminRepositories;
using HS_14_MVC.Infrastructure.Repositories.AuthorRepositories;
using HS_14_MVC.Infrastructure.Repositories.BookRepositories;
using HS_14_MVC.Infrastructure.Repositories.CategoryRepositories;
using HS_14_MVC.Infrastructure.Repositories.ProfileUserRepositories;
using HS_14_MVC.Infrastructure.Repositories.PublisherRepositories;
using HS_14_MVC.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString(AppDbContext.DevConnectionString));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IProfileUserRepository, ProfileUserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();


            AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();  //mig atarken yoruma al !!
            return services;

        }
    }
}
