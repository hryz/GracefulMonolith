using System.Collections.Generic;

namespace Data.Read.Abstract
{
    public interface IPageResult<out T>
    {
        long Count { get; }
        IEnumerable<T> Page { get; }
    }
}