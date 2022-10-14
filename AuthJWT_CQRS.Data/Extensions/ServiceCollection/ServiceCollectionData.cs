using AuthJWT_CQRS.Data.Context;
using AuthJWT_CQRS.Data.Repositories.User;
using AuthJWT_CQRS.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AuthJWT_CQRS.Data.Extensions.ServiceCollection
{
    public static class ServiceCollectionData
    {
        public static IServiceCollection AddServiceData(this IServiceCollection services)
        {
            services.TryAddScoped<IUserRepo, UserRepo>();
            services.AddDbContext<AppDbContext>();
            services.AddIdentity<UserEntity, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
                o.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            return services;

        }
    }
}
