using Common.Repository.EfCore.Options;
using Common.Repository.EfCore.Repository;
using Common.Repository.Repository;
using Common.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Repository.EfCore.Exceptions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfCoreDbContext<TDbContext>(this IServiceCollection serviceCollection,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped,
            Action<RepositoryOptions<TDbContext>>? repositoryOptions = null)
            where TDbContext : DbContext
        {
            var contextType = typeof(TDbContext);
            if (AddedDbContext.GetContextType == contextType)
                return serviceCollection;


            serviceCollection.AddDbContext<TDbContext>(optionsAction, contextLifetime, optionsLifetime);
            AddedDbContext.AddContextType<TDbContext>();

            var repoOpts = new RepositoryOptions<TDbContext>();
            repositoryOptions?.Invoke(repoOpts);
            serviceCollection.AddSingleton(repoOpts);

            AddRepositories(serviceCollection, typeof(TDbContext));

            return serviceCollection;
        }


        public static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, EfCoreUnitOfWork>()
                .AddScoped(x => new Lazy<IUnitOfWork>(x.GetRequiredService<IUnitOfWork>()));

            return serviceCollection;
        }

        private static void AddRepositories(IServiceCollection serviceCollection, Type dbContextType)
        {
            foreach (var entityType in GetGenericRepoTypes(dbContextType))
            {
                var genericRepoInterfaceType = typeof(IRepository<>).MakeGenericType(entityType);

                if (serviceCollection.IsAlreadyAddedInServices(genericRepoInterfaceType))
                    continue;

                var genericRepoImplementationType = typeof(EFCoreRepository<,>).MakeGenericType(dbContextType, entityType);
                serviceCollection.AddScoped(genericRepoInterfaceType, genericRepoImplementationType);
            }

            foreach (var entityType in GetQueryRepoTypes(dbContextType))
            {
                var genericRepoInterfaceType = typeof(IQueryRepository<>).MakeGenericType(entityType);
                if (serviceCollection.IsAlreadyAddedInServices(genericRepoInterfaceType))
                    continue;

                var genericRepoImplementationType = typeof(EfCoreQueryRepository<,>).MakeGenericType(dbContextType, entityType);
                serviceCollection.AddScoped(genericRepoInterfaceType, genericRepoImplementationType);
            }
        }

        private static bool IsAlreadyAddedInServices(this IServiceCollection serviceCollection, Type type)
        {
            return serviceCollection.Any(x => x.ServiceType == type);
        }

        private static IEnumerable<Type> GetGenericRepoTypes(Type dbContextType)
        {
            return dbContextType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.IsAssignableToGenericType(typeof(DbSet<>))
                            && x.GetCustomAttributes<RepositoryAttribute>().FirstOrDefault(y => !y.CreateGenericRepository) == null)
                .Select(x => x.PropertyType.GenericTypeArguments[0]);
        }

        private static IEnumerable<Type> GetQueryRepoTypes(Type dbContextType)
        {
            return dbContextType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.PropertyType.IsAssignableToGenericType(typeof(DbSet<>))
                            && x.GetCustomAttributes<RepositoryAttribute>().FirstOrDefault(y => !y.CreateQueryRepository) == null
                ).Select(x => x.PropertyType.GenericTypeArguments[0]);
        }

        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            if (givenType.GetTypeInfo().IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            Type[] interfaces = givenType.GetInterfaces();
            foreach (Type type in interfaces)
            {
                if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.GetTypeInfo().BaseType == null)
            {
                return false;
            }

            return givenType.GetTypeInfo().BaseType.IsAssignableToGenericType(genericType);
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RepositoryAttribute : Attribute
    {
        public bool CreateGenericRepository { get; set; } = true;
        public bool CreateQueryRepository { get; set; } = true;
    }
}
