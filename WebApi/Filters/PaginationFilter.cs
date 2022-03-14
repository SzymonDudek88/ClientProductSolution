namespace WebApi.Filters
{
    public class PaginationFilter // tylko i wylacznie filtruje dane wejsciowe 
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        private const int maxPageSize = 10;
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = maxPageSize;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageSize = pageSize > maxPageSize ? maxPageSize : pageSize;
            PageNumber = pageNumber < 1 ? 1 : pageNumber; // if user put lesst than 1 then select first
        }
    }
}
