using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Dishes
{
    public sealed class IngredientPortionDto
    {
        [Range(1, int.MaxValue)] public int IngredientId { get; set; }
        [Range(1, 20000)] public decimal QuantityGrams { get; set; }
    }
}
