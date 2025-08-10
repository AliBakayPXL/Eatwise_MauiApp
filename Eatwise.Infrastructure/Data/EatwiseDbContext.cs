using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eatwise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eatwise.Infrastructure.Data
{
    public class EatwiseDbContext : DbContext
    {
        public EatwiseDbContext(DbContextOptions<EatwiseDbContext> options)
           : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
