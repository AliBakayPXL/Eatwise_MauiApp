using Eatwise.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatwise.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } //Primary key
        public string Name { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int HeightCm { get; set; }
        public decimal Weightkg { get; set; }
        public int Age { get; set; }
        public Goal Goal { get; set; }
        public Role Role { get; set; } = Role.User;

        // Navigatie (optioneel, handig voor EF)
        //public ICollection<EatenItem> EatenItems { get; set; } = new List<EatenItem>();
    }
}
