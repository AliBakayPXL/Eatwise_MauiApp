using Eatwise.Application.Interfaces;
using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Services
{
   public class CatalogService : ICatalogService
    {
        private readonly IIngredientRepository _ingredients;
        private readonly IDishRepository _dishes;

        public CatalogService(IIngredientRepository ingredients, IDishRepository dishes)
        {
            _ingredients = ingredients;
            _dishes = dishes;
        }

        // INGREDIENTS
        public Task<List<Ingredient>> SearchIngredientsAsync(string? search, int skip, int take, CancellationToken ct = default)
            => _ingredients.SearchAsync(search, skip, take, ct);

        public Task<Ingredient?> GetIngredientAsync(int id, CancellationToken ct = default)
            => _ingredients.GetByIdAsync(id, ct);


        public async Task AddIngredientAsync(Ingredient ingredient, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name))
                throw new ArgumentException("Name is required.", nameof(ingredient));

            if (await _ingredients.NameExistsAsync(ingredient.Name, null, ct))
                throw new InvalidOperationException("Ingredient name already exists.");

            await _ingredients.AddAsync(ingredient, ct);
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(ingredient.Name))
                throw new ArgumentException("Name is required.", nameof(ingredient));

            if (await _ingredients.NameExistsAsync(ingredient.Name, ingredient.Id, ct))
                throw new InvalidOperationException("Ingredient name already exists.");

            await _ingredients.UpdateAsync(ingredient, ct);
        }

        public Task DeleteIngredientAsync(int id, CancellationToken ct = default)
            => _ingredients.DeleteAsync(id, ct);

        // DISHES
        public Task<List<Dish>> SearchDishesAsync(string? search, int skip, int take, CancellationToken ct = default)
            => _dishes.SearchAsync(search, skip, take, ct);

        public Task<Dish?> GetDishAsync(int id, bool includeIngredients, CancellationToken ct = default)
            => includeIngredients ? _dishes.GetByIdWithIngredientsAsync(id, ct)
                                  : _dishes.GetByIdAsync(id, ct);

        public async Task AddDishAsync(Dish dish, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(dish.Name))
                throw new ArgumentException("Name is required.", nameof(dish));

            if (await _dishes.NameExistsAsync(dish.Name, null, ct))
                throw new InvalidOperationException("Dish name already exists.");

            // Aanname: DishIngredients is gevuld door de caller (API)
            await _dishes.AddAsync(dish, ct);
        }

        public async Task UpdateDishAsync(Dish dish, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(dish.Name))
                throw new ArgumentException("Name is required.", nameof(dish));

            if (await _dishes.NameExistsAsync(dish.Name, dish.Id, ct))
                throw new InvalidOperationException("Dish name already exists.");

            await _dishes.UpdateAsync(dish, ct);
        }

        public Task DeleteDishAsync(int id, CancellationToken ct = default)
            => _dishes.DeleteAsync(id, ct);


    }
}
