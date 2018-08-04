namespace Data.Read.Abstract
{
    public interface IPageQuery<out T> : IQuery<IPageResult<T>>
    {
        int PageNo { get; }
        int PageSize { get; }
    }

    public static class PageQueryExtensions
    {
        public static int Skip<T>(this IPageQuery<T> query) => (query.PageNo - 1) * query.PageSize;
        public static int Take<T>(this IPageQuery<T> query) => query.PageSize;
    }
}
