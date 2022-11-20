namespace Common.Lists.Pagination
{
    public class PagedList<TItem>
    {
        public PagingDetails PagingDetails { get; }

        public List<TItem> List { get; }

        public PagedList(IQueryable<TItem> source, int pageIndex, int pageSize)
        {
            PagingDetails = new PagingDetails(pageIndex, pageSize, source?.Count() ?? 0);
            List = source?.Skip(PagingDetails.PageIndex * PagingDetails.PageSize).Take(PagingDetails.PageSize).ToList();
        }

        public PagedList(IEnumerable<TItem> source, int pageIndex, int pageSize, int totalCount)
        {
            PagingDetails = new PagingDetails(pageIndex, pageSize, totalCount);
            List = source?.ToList();
        }

        public PagedList(IEnumerable<TItem> source, PagingDetails pageDetails)
        {
            PagingDetails = pageDetails;
            List = source?.ToList();
        }
    }
}
