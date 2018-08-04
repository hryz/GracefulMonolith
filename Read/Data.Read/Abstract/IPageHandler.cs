using System.Collections.Generic;

namespace Data.Read.Abstract
{
    public interface IPageHandler<in TQuery, TResult> : IQueryHandler<TQuery, IPageResult<TResult>> where TQuery : IPageQuery<TResult>
    {

    }

    public static class PageHandlerExtensions
    {
        public static IPageResult<TResult> Result<TQuery, TResult>(
            this IPageHandler<TQuery, TResult> handler, 
            int count, 
            IEnumerable<TResult> page) 
                where TQuery : IPageQuery<TResult>
        {
            return new PageResult<TResult>(count, page);
        }
    }
}