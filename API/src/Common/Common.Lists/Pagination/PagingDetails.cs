namespace Common.Lists.Pagination
{
    public class PagingDetails
    {
        public int PageIndex { get; private set; }
        public int PageNumber => PageIndex + 1;
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public int TotalPages
        {
            get
            {
                int num = TotalCount / PageSize;
                if (TotalCount % PageSize > 0)
                    num++;
                return num;
            }
        }

        public bool HasPreviousPage => PageIndex > 0;
        public bool HasNextPage => PageIndex + 1 < TotalPages;
        public int FirstItemIndex => PageIndex * PageSize + 1;
        public int LastItemIndex => Math.Min(TotalCount, PageIndex * PageSize + PageSize);
        public bool IsFirstPage => PageIndex <= 0;
        public bool IsLastPage => PageIndex >= TotalPages - 1;

        public PagingDetails(int pageIndex, int pageSize, int totalCount)
        {
            PageIndex = (pageIndex >= 0) ? pageIndex : 0;
            PageSize = (pageSize >= 0) ? pageSize : 0;
            TotalCount = (totalCount >= 0) ? totalCount : 0;
        }
    }
}
