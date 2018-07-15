namespace Data.Read.Abstract
{
    public interface IPageQuery<out T> : IQuery<IPageResult<T>>
    {
        int PageNo { get; }
        int PageSize { get; }
    }
}
