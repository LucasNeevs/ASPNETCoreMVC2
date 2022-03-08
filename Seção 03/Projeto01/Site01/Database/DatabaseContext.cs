using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site01.Models;

namespace Site01.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Entity Framework - garantir que o banco seja criado pelo EF
            Database.EnsureCreated();
        }
    }
}
