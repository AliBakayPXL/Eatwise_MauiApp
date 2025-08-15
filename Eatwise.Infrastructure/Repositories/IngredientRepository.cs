using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eatwise.Application.Interfaces;
using Eatwise.Domain.Entities;
using Eatwise.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eatwise.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly EatwiseDbContext _db;

        public IngredientRepository(EatwiseDbContext db) => _db = db;

        public Task<List<Ingredient>> GetAllAsync(CancellationToken ct = default) =>
            _db.Ingredients.AsNoTracking().OrderBy(i => i.Name).ToListAsync(ct);

        public Task<List<Ingredient>> SearchAsync(string? search, int skip, int take, CancellationToken ct = default)
        {
            var query = _db.Ingredients.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(i => i.Name.Contains(search));

            return query
                .OrderBy(i => i.Name)
                .Skip(Math.Max(0, skip))
                .Take(Math.Max(1, take))
                .ToListAsync(ct);
        }

        public Task<Ingredient?> GetByIdAsync(int id, CancellationToken ct = default) =>
            _db.Ingredients.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, ct);

        public Task<bool> NameExistsAsync(string name, int? excludeId = null, CancellationToken ct = default)
        {
            var q = _db.Ingredients.AsNoTracking().Where(i => i.Name == name);
            if (excludeId is int ex) q = q.Where(i => i.Id != ex);
            return q.AnyAsync(ct);
        }

        public async Task AddAsync(Ingredient ingredient, CancellationToken ct = default)
        {
            _db.Ingredients.Add(ingredient);
            await _db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Ingredient ingredient, CancellationToken ct = default)
        {
            _db.Ingredients.Update(ingredient);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _db.Ingredients.FirstOrDefaultAsync(i => i.Id == id, ct);
            if (entity is null) return;

            _db.Ingredients.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}
