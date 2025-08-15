using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Ingredients
{
    public sealed class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CaloriesPer100g { get; set; }
        public decimal ProteinPer100g { get; set; }
        public decimal FatPer100g { get; set; }
        public decimal SugarPer100g { get; set; }
    }
}
