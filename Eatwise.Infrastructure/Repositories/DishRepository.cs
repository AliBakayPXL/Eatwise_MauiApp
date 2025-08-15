using Eatwise.Domain.Entities;
using Eatwise.Infrastructure.Data;
using Eatwise.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Infrastructure.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly EatwiseDbContext _db;

        public DishRepository(EatwiseDbContext db) => _db = db;

        public Task<List<Dish>> SearchAsync(string? search, int skip, int take, CancellationToken ct = default)
        {
            var query = _db.Dishes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(d => d.Name.Contains(search));

            return query
                .OrderBy(d => d.Name)
                .Skip(Math.Max(0, skip))
                .Take(Math.Max(1, take))
                .ToListAsync(ct);
        }

        public Task<Dish?> GetByIdAsync(int id, CancellationToken ct = default) =>
            _db.Dishes.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, ct);

        public Task<Dish?> GetByIdWithIngredientsAsync(int id, CancellationToken ct = default) =>
            _db.Dishes
               .AsNoTracking()
               .Include(d => d.DishIngredients)
                   .ThenInclude(di => di.Ingredient)
               .FirstOrDefaultAsync(d => d.Id == id, ct);

        public async Task AddAsync(Dish dish, CancellationToken ct = default)
        {
            // Verwacht: dish.DishIngredients is gevuld met (IngredientId, QuantityGrams)
            _db.Dishes.Add(dish);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Dish dish, CancellationToken ct = default)
        {
            // Laad bestaande + samenstelling
            var existing = await _db.Dishes
                .Include(d => d.DishIngredients)
                .FirstOrDefaultAsync(d => d.Id == dish.Id, ct);

            if (existing is null) return;

            // Naam bijwerken
            existing.Name = dish.Name;

            // Samenstelling vervangen (simpel en robuust)
            _db.DishIngredients.RemoveRange(existing.DishIngredients);
            existing.DishIngredients = dish.DishIngredients;

            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == id, ct);
            if (entity is null) return;

            _db.Dishes.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }

        public Task<bool> NameExistsAsync(string name, int? excludeId = null, CancellationToken ct = default)
        {
            var q = _db.Dishes.AsNoTracking().Where(d => d.Name == name);
            if (excludeId is int ex) q = q.Where(d => d.Id != ex);
            return q.AnyAsync(ct);
        }
    }
}
