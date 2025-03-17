using HS_14_MVC.Application.Services.AccountServices;
using HS_14_MVC.Application.Services.AuthorServices;
using HS_14_MVC.Application.Services.BookServices;
using HS_14_MVC.Application.Services.CategoryServices;
using HS_14_MVC.Application.Services.ProfileUserServices;
using HS_14_MVC.Application.Services.PublisherServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Application.Extentions
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services )
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublisherService, PublisherService>();  
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileUserService, ProfileUserService>();

            return services;
        }
    }
}
