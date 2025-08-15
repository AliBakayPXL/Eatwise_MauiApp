using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Eaten
{
    public sealed class AddEatenItemRequest
    {
        public DateTime Date { get; set; }
        [Range(1, int.MaxValue)] public int? IngredientId { get; set; }
        [Range(1, int.MaxValue)] public int? DishId { get; set; }
        [Range(1, 20000)] public decimal QuantityGrams { get; set; }
    }
}
