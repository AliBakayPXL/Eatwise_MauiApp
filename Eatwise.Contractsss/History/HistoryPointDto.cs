using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.History
{
    public sealed class HistoryPointDto
    {
        public DateTime Date { get; set; } // bij Week/Month: start van de periode
        public int Calories { get; set; }
        public decimal Protein { get; set; }
    }
}
