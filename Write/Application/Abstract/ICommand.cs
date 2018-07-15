using MediatR;

namespace Application.Abstract
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
