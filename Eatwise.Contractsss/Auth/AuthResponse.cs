using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Contracts.Auth
{
    public sealed class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAtUtc { get; set; }
        public UserSummaryDto User { get; set; } = new UserSummaryDto();
    }
}
