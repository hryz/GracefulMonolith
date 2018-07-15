namespace Data.Read.Abstract
{
    public interface IPageHandler<in TQuery, TResult> : IQueryHandler<TQuery, IPageResult<TResult>> where TQuery : IPageQuery<TResult>
    {

    }
}