using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tocatu.Models;

namespace tocatu.Context
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
