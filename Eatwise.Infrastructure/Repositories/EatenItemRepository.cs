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
    public class EatenItemRepository : IEatenItemRepository
    {
        private readonly EatwiseDbContext _db;

        public EatenItemRepository(EatwiseDbContext db) => _db = db;

        public Task<List<EatenItem>> GetDayAsync(int userId, DateOnly date, CancellationToken ct = default) =>
            _db.EatenItems
               .AsNoTracking()
               .Where(e => e.UserId == userId && e.Date == date)
               .Include(e => e.Dish)
               .Include(e => e.Ingredient)
               .OrderBy(e => e.Id)
               .ToListAsync(ct);

        public Task<List<EatenItem>> GetRangeAsync(int userId, DateOnly from, DateOnly to, CancellationToken ct = default) =>
            _db.EatenItems
               .AsNoTracking()
               .Where(e => e.UserId == userId && e.Date >= from && e.Date <= to)
               .Include(e => e.Dish)
               .Include(e => e.Ingredient)
               .OrderBy(e => e.Date)
               .ThenBy(e => e.Id)
               .ToListAsync(ct);

        public async Task AddAsync(EatenItem item, CancellationToken ct = default)
        {
            _db.EatenItems.Add(item);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, int userId, CancellationToken ct = default)
        {
            var entity = await _db.EatenItems.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId, ct);
            if (entity is null) return;

            _db.EatenItems.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}
