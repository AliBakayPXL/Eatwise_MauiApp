using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Domain.Entities
{
    public class EatenItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        // Alleen de dag (EF Core 8 ondersteunt DateOnly; anders kun je DateTime gebruiken en alleen .Date hanteren)
        public DateOnly Date { get; set; }

        // Eentje van de twee invullen (service zorgt dat het klopt)
        public int? DishId { get; set; }
        public Dish? Dish { get; set; }

        public int? IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }

        //Eaten quantity in grams
        public decimal QuantityGrams { get; set; }
    }
}
