using Common.Repository.EfCore.Exceptions;
using Common.Repository.EfCore.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBS.Persistence.Database;

namespace RBS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("AppContextConnection"));
            //});

            services.AddEfCoreDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppContextConnection"));
            },
            repositoryOptions: options =>
            {
                options.SaveChangeStrategy = SaveChangeStrategy.PerOperation;
            });

            services.AddUnitOfWork();

            return services;
        }
    }
}
