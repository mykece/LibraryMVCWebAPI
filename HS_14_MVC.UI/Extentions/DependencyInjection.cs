using AspNetCoreHero.ToastNotification;
using HS_14_MVC.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace HS_14_MVC.UI.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIService(this IServiceCollection services)
        {
            IAddIdentityService(services);
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.DurationInSeconds = 5;
                config.Position = NotyfPosition.BottomRight;
                config.IsDismissable = true;
            });
            return services;
        }

        private static IServiceCollection IAddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            return services;

        }
    }
}
