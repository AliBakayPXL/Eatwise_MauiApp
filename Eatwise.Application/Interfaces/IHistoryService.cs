using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface IHistoryService
    {
        Task<IReadOnlyList<HistoryPoint>> GetHistoryAsync(int userId, DateOnly from, DateOnly to, CancellationToken ct = default);
    }

    // Klein read-model voor grafiek/lijst
    public sealed class HistoryPoint
    {
        public DateOnly Date { get; init; }
        public int Calories { get; init; }
        public decimal Protein { get; init; }
    }
}
