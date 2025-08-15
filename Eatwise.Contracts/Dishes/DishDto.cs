using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Dishes
{
    public sealed class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public IReadOnlyList<DishComponentDto> Components { get; set; } = new List<DishComponentDto>();
    }
}
