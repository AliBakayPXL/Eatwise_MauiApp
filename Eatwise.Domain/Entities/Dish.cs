using Eatwise.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
    }
}
