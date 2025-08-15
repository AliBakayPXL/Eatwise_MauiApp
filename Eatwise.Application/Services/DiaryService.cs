using Eatwise.Application.Interfaces;
using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IEatenItemRepository _eaten;

        public DiaryService(IEatenItemRepository eaten)
        {
            _eaten = eaten;
        }

        public Task<List<EatenItem>> GetDayAsync(int userId, DateOnly date, CancellationToken ct = default)
            => _eaten.GetDayAsync(userId, date, ct);

        public async Task AddEatenItemAsync(EatenItem item, CancellationToken ct = default)
        {
            // Businessregel: precies één van DishId/IngredientId moet gevuld zijn
            var hasDish = item.DishId.HasValue;
            var hasIngredient = item.IngredientId.HasValue;
            if (hasDish == hasIngredient)
                throw new ArgumentException("Exactly one of DishId or IngredientId must be provided.");

            if (item.QuantityGrams <= 0)
                throw new ArgumentException("QuantityGrams must be positive.");

            await _eaten.AddAsync(item, ct);
        }

        public Task DeleteEatenItemAsync(int id, int userId, CancellationToken ct = default)
            => _eaten.DeleteAsync(id, userId, ct);
    }
}
