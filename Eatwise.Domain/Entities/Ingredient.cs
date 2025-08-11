using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Per 100 grams (Eurpean standard)
        public int CaloriesPer100g { get; set; }
        public decimal ProteinPer100g { get; set; }
        public decimal FatPer100g { get; set; }
        public decimal SugarPer100g { get; set; }

        // Navigatie
        public ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
    }
}
