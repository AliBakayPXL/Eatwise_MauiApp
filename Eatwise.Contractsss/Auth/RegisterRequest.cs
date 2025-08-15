using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Eatwise.Contracts.Auth
{
    public sealed class RegisterRequest
    {
        [Required, StringLength(100)] public string Name { get; set; } = string.Empty;
        public GenderDto Gender { get; set; }
        [Range(50, 260)] public int HeightCm { get; set; }
        [Range(20, 400)] public decimal WeightKg { get; set; }   // EF: configure precision in model
        [Range(13, 120)] public int Age { get; set; }
        [Required, EmailAddress, StringLength(256)] public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)] public string Password { get; set; } = string.Empty;
        public GoalDto Goal { get; set; }
    }
}
