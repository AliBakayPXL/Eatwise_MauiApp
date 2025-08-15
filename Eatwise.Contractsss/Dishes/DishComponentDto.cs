using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Dishes
{
    public sealed class DishComponentDto
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public decimal QuantityGrams { get; set; }
    }
}
