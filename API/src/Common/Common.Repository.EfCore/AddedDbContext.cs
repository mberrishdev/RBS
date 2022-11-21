using Microsoft.EntityFrameworkCore;

namespace Common.Repository.EfCore
{
    internal class AddedDbContext
    {
        private static Type ContextType;
        internal static Type GetContextType => ContextType;

        internal static void AddContextType<TContext>() where TContext : DbContext
        {
            var contextType = typeof(TContext);
            if (contextType == ContextType)
                return;

            ContextType = contextType;
        }
    }
}
