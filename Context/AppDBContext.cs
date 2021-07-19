using ApiPracticas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPracticas.Context
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<rol> rol { get; set; }
    }
}
