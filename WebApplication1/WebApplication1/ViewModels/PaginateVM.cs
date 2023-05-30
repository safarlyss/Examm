namespace WebApplication1.ViewModels
{
    public class PaginateVM<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
    }
}
