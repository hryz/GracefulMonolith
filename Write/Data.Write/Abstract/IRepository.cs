using System.Threading;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Data.Write.Abstract
{
    public interface IRepository<TAggregate, in TId> where TAggregate : IAggregate<TId>
    {
        Task<TAggregate> Get(TId id, CancellationToken token);
        Task Update(TAggregate aggregate, CancellationToken token);
        Task Delete(TId id, CancellationToken token);
    }
}
