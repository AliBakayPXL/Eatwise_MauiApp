using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Ingredients
{
    public sealed class SaveIngredientsRequest
    {
        [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
        [Range(0, 1200)] public int CaloriesPer100g { get; set; }
        [Range(0, 1000)] public decimal ProteinPer100g { get; set; }
        [Range(0, 1000)] public decimal FatPer100g { get; set; }
        [Range(0, 1000)] public decimal SugarPer100g { get; set; }
    }
}
