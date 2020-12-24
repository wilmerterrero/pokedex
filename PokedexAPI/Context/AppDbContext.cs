using Microsoft.EntityFrameworkCore;
using PokedexAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Pokemon> Pokemones { get; set; }
    }
}
