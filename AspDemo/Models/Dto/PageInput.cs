namespace AspDemo.Models.Dto
{
    [Serializable]
    public class PageInput
    {
        public PageInput() { }

        public PageInput(
            string searchText = "",
            int pageSize = 10,
            int pageNumber = 1,
            string sortName = "",
            string sortOrder = ""
        )
        {
            SearchText = searchText;
            PageSize = pageSize;
            PageNumber = pageNumber;
            SortName = sortName;
            SortOrder = sortOrder;
        }

        public virtual string? SearchText { get; set; } = string.Empty;
        public virtual int PageSize { get; set; } = 10;
        public virtual int PageNumber { get; set; } = 1;

        public virtual int Position => (PageNumber - 1) * PageSize;
        public virtual string? SortName { get; set; }
        public virtual string? SortOrder { get; set; }
    }

    [Serializable]
    public class PageInput<T> : PageInput
        where T : class
    {
        public T? Filter { get; set; }
    }
}
