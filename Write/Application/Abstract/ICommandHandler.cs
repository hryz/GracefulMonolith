using MediatR;

namespace Application.Abstract
{
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult>
    {
    }
}
