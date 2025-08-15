using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface ICatalogService
    {
        // Ingredients
        Task<List<Ingredient>> SearchIngredientsAsync(string? search, int skip, int take, CancellationToken ct = default);
        Task<Ingredient?> GetIngredientAsync(int id, CancellationToken ct = default);
        Task AddIngredientAsync(Ingredient ingredient, CancellationToken ct = default);
        Task UpdateIngredientAsync(Ingredient ingredient, CancellationToken ct = default);
        Task DeleteIngredientAsync(int id, CancellationToken ct = default);

        // Dishes
        Task<List<Dish>> SearchDishesAsync(string? search, int skip, int take, CancellationToken ct = default);
        Task<Dish?> GetDishAsync(int id, bool includeIngredients, CancellationToken ct = default);
        Task AddDishAsync(Dish dish, CancellationToken ct = default);
        Task UpdateDishAsync(Dish dish, CancellationToken ct = default);
        Task DeleteDishAsync(int id, CancellationToken ct = default);
    }
}
