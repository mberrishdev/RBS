namespace Common.Lists.Sorting
{
    public class SortingDetails<TEntity> where TEntity : class
    {
        public SortingDetails(SortItem<TEntity> sortItem)
        {
            if (sortItem == null)
                throw new ArgumentNullException(nameof(sortItem));
            if (sortItem.SortBy is null)
                throw new ArgumentNullException(nameof(sortItem));
            SortItem = sortItem;
        }
        public SortItem<TEntity> SortItem { get; set; }
    }
}
