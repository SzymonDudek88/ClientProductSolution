using System;
using System.Collections.Generic;
using WebApi.Filters;
using WebApi.Wrappers;

namespace WebApi.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedResponse<T> (  IEnumerable<T> pagedData,
            PaginationFilter validPaginationFilter,
            int totalRecords)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validPaginationFilter.PageSize);
            var roundTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            int currentPage = validPaginationFilter.PageNumber;
            response.TotalPages = roundTotalPages;
            response.TotalRecords = totalRecords;
            response.PreviousPage = currentPage > 1 ? true : false;
            response.NextPage = currentPage < roundTotalPages ? true : false;
            return response;
        }


    }
}
