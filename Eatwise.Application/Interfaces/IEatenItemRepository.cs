using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface IEatenItemRepository
    {
        Task<List<EatenItem>> GetDayAsync(int userId, DateOnly date, CancellationToken ct = default);
        Task<List<EatenItem>> GetRangeAsync(int userId, DateOnly from, DateOnly to, CancellationToken ct = default);

        Task AddAsync(EatenItem item, CancellationToken ct = default);
        Task DeleteAsync(int id, int userId, CancellationToken ct = default);

    }
}
