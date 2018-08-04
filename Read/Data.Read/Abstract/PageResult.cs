using System.Collections.Generic;

namespace Data.Read.Abstract
{
    internal class PageResult<T> : IPageResult<T>
    {
        public PageResult(long count, IEnumerable<T> page)
        {
            Count = count;
            Page = page;
        }

        public long Count { get; }
        public IEnumerable<T> Page { get; }
    }
}