using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextCampeonatos : DbContext
    {
        public DbContextCampeonatos(DbContextOptions<DbContextCampeonatos> options) : base(options)
        {

        }
        //-----------------------------------Campeonatos----------------------------------------
        //Creando tabla de Campeonatos
        public DbSet<Campeonatos> Campeonatos { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Campeonatos en BD
            builder.Entity<Campeonatos>().ToTable("Campeonatos");
            builder.Entity<Campeonatos>().HasKey(u => u.Id);
            builder.Entity<Campeonatos>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Campeonatos>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Campeonatos>().Property(u => u.FechaInicio).HasColumnName("fechaInicio");
            builder.Entity<Campeonatos>().Property(u => u.FechaCierre).HasColumnName("fechaCierre");
            builder.Entity<Campeonatos>().Property(u => u.NumeroEquiposP).HasColumnName("numeroEquiposP");
            builder.Entity<Campeonatos>().Property(u => u.Activo).HasColumnName("activo");
            builder.Entity<Campeonatos>().Property(u => u.IdLiga).HasColumnName("idLiga");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Campeonatos
        //metodo para retornar lista de registros de la tabla
        public List<Campeonatos> ObtenerCampeonatos()
        {
            return Campeonatos.FromSqlRaw("exec spGetCampeonatos").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Campeonatos ObtenerCampeonatoId(int id)
        {
            var Campeonato = Campeonatos.FromSqlInterpolated($"exec spGetCampeonato {id}").AsEnumerable().FirstOrDefault();
            return Campeonato;
        }

        //metodo para insertar datos a la tabla
        public void CrearCampeonato(string nombre, DateTime fechaInicio, DateTime fechaCierre, int numeroEquiposP, string activo, int idLiga) { 
            Database.ExecuteSqlRaw("exec spInsertarCampeonatos {0}, {1}, {2}, {3}, {4}, {5}", nombre, fechaInicio, fechaCierre, numeroEquiposP, activo, idLiga);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarCampeonato(int id, string nombre, DateTime fechaInicio, DateTime fechaCierre, int numeroEquiposP, string activo, int idLiga)
        {
            Database.ExecuteSqlRaw("exec spActualizarCampeonatos {0} ,{1}, {2}, {3}, {4}, {5}, {6}", id, nombre, fechaInicio, fechaCierre, numeroEquiposP, activo, idLiga);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarCampeonato(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarCampeonatos {0}", id);
        }

    }
}
