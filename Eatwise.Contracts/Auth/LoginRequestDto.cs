using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Auth
{
    public sealed class LoginRequestDto
    {
        [Required, EmailAddress, StringLength(256)] public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)] public string Password { get; set; } = string.Empty;
    }
}
