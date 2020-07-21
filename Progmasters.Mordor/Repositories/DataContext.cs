using Microsoft.EntityFrameworkCore;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DbOrc> Orcs { get; set; }
        public DbSet<DbWeapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
