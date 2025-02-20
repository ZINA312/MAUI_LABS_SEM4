using _253503_Kudosh.Persistence.Data;
using _253503_Kudosh.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace _253503_Kudosh.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options)
        {
            services.AddPersistence().AddSingleton<AppDbContext>(provider =>
            {
                var dbContextOptions = options as DbContextOptions<AppDbContext>;
                return new AppDbContext(dbContextOptions);
            });
            return services;
        }
    }
}
