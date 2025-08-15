using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts
{
    public sealed class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalCount { get; }
        public int Page { get; }
        public int PageSize { get; }

        public PagedResult(IReadOnlyList<T> items, int totalCount, int page, int pageSize)
        {
            Items = items ?? Array.Empty<T>();
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;
        }
    }
}
