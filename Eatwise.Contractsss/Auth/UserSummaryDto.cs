using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Auth
{
    public sealed class UserSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GenderDto Gender { get; set; }
        public int HeightCm { get; set; }
        public decimal WeightKg { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public GoalDto Goal { get; set; }
        public bool IsGuest { get; set; }
    }
}
