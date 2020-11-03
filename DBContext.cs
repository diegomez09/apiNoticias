using Microsoft.EntityFrameworkCore;
using NoticiasApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasApi
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modeloCreador)
        {
            new Noticia.Mapeo(modeloCreador.Entity<Noticia>());
            new Autor.Mapeo(modeloCreador.Entity<Autor>());
        }
    }
}
