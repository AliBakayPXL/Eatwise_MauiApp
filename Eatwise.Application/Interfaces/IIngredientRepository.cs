using Eatwise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Application.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllAsync(CancellationToken ct = default);
        Task<List<Ingredient>> SearchAsync(string? search, int skip, int take, CancellationToken ct = default);
        Task<Ingredient?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> NameExistsAsync(string name, int? excludeId = null, CancellationToken ct = default);

        Task AddAsync(Ingredient ingredient, CancellationToken ct = default);
        Task UpdateAsync(Ingredient ingredient, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}
