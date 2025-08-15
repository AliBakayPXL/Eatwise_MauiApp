using Eatwise.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IEatenItemRepository _eaten;

        public HistoryService(IEatenItemRepository eaten) => _eaten = eaten;

        public async Task<IReadOnlyList<HistoryPoint>> GetHistoryAsync(
            int userId, DateOnly from, DateOnly to, CancellationToken ct = default)
        {
            var items = await _eaten.GetRangeAsync(userId, from, to, ct);

            return items
                .GroupBy(i => i.Date)
                .OrderBy(g => g.Key)
                .Select(g => new HistoryPoint
                {
                    Date = g.Key,
                    Calories = 0,
                    Protein = 0m
                })
                .ToList();
        }
    }
}
