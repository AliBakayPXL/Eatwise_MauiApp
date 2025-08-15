using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Dishes
{
    public sealed class SaveDishRequest
    {
        [Required, StringLength(120)] public string Name { get; set; } = string.Empty;

        [MinLength(1)]
        public IReadOnlyList<IngredientPortionDto> Components { get; set; } = new List<IngredientPortionDto>();
    }
}
