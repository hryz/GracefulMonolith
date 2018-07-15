namespace Domain.Abstract
{
    public interface IAggregate<out TId>
    {
        TId Id { get; }
    }
}
