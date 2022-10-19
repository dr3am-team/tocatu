using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tocatu_v2.Models;

namespace Tocatu_v2.Context
{
    public class TocatuContext : DbContext
    {
        public
       TocatuContext(DbContextOptions<TocatuContext> options)
       : base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Banda> Bandas { get; set; }


    }

}
