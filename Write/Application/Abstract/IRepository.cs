using System.Threading;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Application.Abstract
{
    public interface IRepository<TAggregate, TId> where TAggregate : IAggregate<TId>
    {
        Task<TAggregate> Get(TId id, CancellationToken token);
        Task<TId> Create(TAggregate aggregate, CancellationToken token);
        Task Update(TAggregate aggregate, CancellationToken token);
        Task Delete(TId id, CancellationToken token);
    }
}
