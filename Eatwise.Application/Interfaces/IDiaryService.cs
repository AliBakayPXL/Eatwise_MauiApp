using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface IDiaryService
    {
        public interface IDiaryService
        {
            Task<List<EatenItem>> GetDayAsync(int userId, DateOnly date, CancellationToken ct = default);
            Task AddEatenItemAsync(EatenItem item, CancellationToken ct = default);
            Task DeleteEatenItemAsync(int id, int userId, CancellationToken ct = default);
        }
    }
}
