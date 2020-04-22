using MediatR;

namespace Data.Read.Abstract
{
    public interface IQueryHandler<in TQuery, TResult> 
        : IRequestHandler<TQuery, TResult> 
        where TQuery : IQuery<TResult>
    {
    }
}
