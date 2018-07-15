using MediatR;

namespace Data.Read.Abstract
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
