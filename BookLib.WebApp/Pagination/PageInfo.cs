using System;

namespace BookLib.WebApp.Pagination
{
    //Helper class that implements pagination
    public class PageInfo
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public PageInfo(int count, int pageNumber, int pagesize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
    }
}
