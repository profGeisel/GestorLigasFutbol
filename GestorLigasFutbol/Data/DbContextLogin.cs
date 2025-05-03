using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextLogin:DbContext
    {
        public DbContextLogin(DbContextOptions<DbContextLogin> options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuario { get; set; }

    }
}
