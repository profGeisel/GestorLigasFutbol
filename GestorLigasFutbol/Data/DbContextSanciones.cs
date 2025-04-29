using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextSanciones : DbContext
    {
        public DbContextSanciones(DbContextOptions<DbContextSanciones> options) : base(options)
        {

        }
        //-----------------------------------Sanciones----------------------------------------
        //Creando tabla de Sanciones
        public DbSet<Sanciones> Sanciones { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Usuarios en BD
            builder.Entity<Sanciones>().ToTable("Sanciones");
            builder.Entity<Sanciones>().HasKey(u => u.Id);
            builder.Entity<Sanciones>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Sanciones>().Property(u => u.Activa).HasColumnName("activa");
            builder.Entity<Sanciones>().Property(u => u.IdJugador).HasColumnName("idJugador");
            builder.Entity<Sanciones>().Property(u => u.IdEquipo).HasColumnName("idEquipo");
            builder.Entity<Sanciones>().Property(u => u.IdCampeonato).HasColumnName("idCampeonato");
            builder.Entity<Sanciones>().Property(u => u.IdTipoS).HasColumnName("idTipoS");
            
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Sanciones
        //metodo para retornar lista de registros de la tabla
        public List<Sanciones> ObtenerSanciones()
        {
            return Sanciones.FromSqlRaw("exec spGetSanciones").ToList();

        }

        //metodo para retornar un Sanciones segun un id
        public Sanciones ObtenerSancionesId(int id)
        {
            var Sancion = Sanciones.FromSqlInterpolated($"exec spGetSanciones {id}").AsEnumerable().FirstOrDefault();
            return Sancion;
        }

        //metodo para insertar datos a la tabla
        public void CrearSanciones(bool activa, int idJugador, int idEquipo, int idCampeonato, int idTipoS)
        {
            Database.ExecuteSqlRaw("exec spInsertarSanciones {0}, {1}, {2}, {3}, {4}", activa, idJugador, idEquipo, idCampeonato, idTipoS);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarSanciones(int id, bool activa, int idJugador, int idEquipo, int idCampeonato, int idTipoS)
        {
            Database.ExecuteSqlRaw("exec spActualizarSanciones {0} ,{1}, {2}, {3}, {4}, {5}", id, activa, idJugador, idEquipo, idCampeonato, idTipoS);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarSanciones(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarSanciones {0}", id);
        }

    }
}
