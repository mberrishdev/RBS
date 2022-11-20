using System.Linq.Expressions;

namespace Common.Lists.Sorting
{
    public class SortItem<TEntity>
    {
        public SortItem(Expression<Func<TEntity, object>> sortBy, SortDirection sortDirection)
        {
            if (sortBy is null)
                throw new ArgumentNullException(nameof(sortBy));

            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public Expression<Func<TEntity, object>> SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

    }
}
