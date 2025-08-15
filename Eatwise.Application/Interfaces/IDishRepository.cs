using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface IDishRepository
    {
        Task<List<Dish>> SearchAsync(string? search, int skip, int take, CancellationToken ct = default);
        Task<Dish?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Dish?> GetByIdWithIngredientsAsync(int id, CancellationToken ct = default);

        Task AddAsync(Dish dish, CancellationToken ct = default);      // dish.DishIngredients vooraf vullen
        Task UpdateAsync(Dish dish, CancellationToken ct = default);   // vervangt samenstelling
        Task DeleteAsync(int id, CancellationToken ct = default);

        Task<bool> NameExistsAsync(string name, int? excludeId = null, CancellationToken ct = default);
    }
}
