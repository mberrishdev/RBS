using Microsoft.Extensions.DependencyInjection;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;

namespace RBS.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
