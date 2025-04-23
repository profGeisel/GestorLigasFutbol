using System.Collections.Generic;
using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Mostrando datos en tabla de Usuarios
        public DbSet<Usuarios> Usuarios { get; set; }
        //Mostrando datos en tabla de TipoUsuarios
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }
    }
}
