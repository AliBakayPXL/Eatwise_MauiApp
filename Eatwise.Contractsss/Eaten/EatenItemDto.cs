using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Eaten
{
    public sealed class EatenItemDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public decimal QuantityGrams { get; set; }
        public int Calories { get; set; }
        public decimal Protein { get; set; }
    }
}
