using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Domain.Entities
{
    public class DishIngredient
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }

        //Quantity of this ingredient in the dish
        public decimal QuantityGrams { get; set; }

        //Navigate
        public Dish? Dish { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
