﻿using HS_14_MVC.Domain.Entities;
using HS_14_MVC.Domain.Enums;
using HS_14_MVC.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_14_MVC.Infrastructure.Seeds
{
    public static class AdminSeed
    {
        private const string adminEmail = "admin@bilgeadam.com";
        private const string adminPassword = "Password.1";

        public static async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("DataContext"));
            AppDbContext context = new AppDbContext(dbContextBuilder.Options);
            if (!context.Roles.Any(role => role.Name == "Admin") )
            {
                await AddRoles(context);
            }
            if (!context.Users.Any(user=> user.Email ==adminEmail))
            {
                await AddAdmin(context);
            }
        }

        private static async Task AddAdmin(AppDbContext context)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpperInvariant(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpperInvariant(),
                EmailConfirmed = true
            };
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, adminPassword);
            await context.Users.AddAsync(user);

            var adminRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Admin.ToString())!.Id;
            await context.UserRoles.AddAsync(new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = user.Id,
            });

            await context.Admins.AddAsync(new Admin()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = adminEmail,
                IdentityId = user.Id
            });
            await context.SaveChangesAsync();
        }

        private static async Task AddRoles(AppDbContext context)
        {
            string[] roles = Enum.GetNames(typeof(Roles));  // Enumda bulunan verilerin isimlerini dizi olarak döner
            for (int i = 0; i < roles.Length; i++)
            {
                if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
                {
                    continue;
                }
                IdentityRole role = new IdentityRole()
                {
                    Name = roles[i],
                    NormalizedName = roles[i].ToUpperInvariant()
                };
                await context.Roles.AddAsync(role);
                await context.SaveChangesAsync();
            }
        }
    }
}
