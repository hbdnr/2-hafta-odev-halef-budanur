namespace EduFlow_Odev2.Base
{
    public class QueryResource
    {

        public int Page { get; }
        public int PageSize { get; }

        public QueryResource(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;

            if (Page <= 0)
                Page = 1;

            if (PageSize <= 0 || PageSize > 20)
                PageSize = 10;
        }
    }
}
