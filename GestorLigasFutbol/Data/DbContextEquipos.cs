using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextEquipos : DbContext
    {
        public DbContextEquipos(DbContextOptions<DbContextEquipos> options) : base(options)
        {

        }
        //-----------------------------------EQUIPOS----------------------------------------
        //Creando tabla de Equipos
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<Campeonatos> Campeonatos { get; set; }
        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Usuarios en BD
            builder.Entity<Equipos>().ToTable("Equipos");
            builder.Entity<Equipos>().HasKey(u => u.Id);
            builder.Entity<Equipos>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Equipos>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Equipos>().Property(u => u.CorreoE).HasColumnName("correoE");
            builder.Entity<Equipos>().Property(u => u.Lugar).HasColumnName("lugar");
            builder.Entity<Equipos>().Property(u => u.FechaFundacion).HasColumnName("fechaFundacion");
            builder.Entity<Equipos>().Property(u => u.Descripcion).HasColumnName("descripcion");
            builder.Entity<Equipos>().Property(u => u.NumIdentificacion).HasColumnName("numIdentificacion");
            builder.Entity<Equipos>().Property(u => u.IdCampeonato).HasColumnName("idCampeonato");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Equipos
        //metodo para retornar lista de registros de la tabla
        public List<Equipos> ObtenerEquipos()
        {
            return Equipos.FromSqlRaw("exec spGetEquipos").ToList();

        }

        //metodo para retornar un Equipo segun un id
        public Equipos ObtenerEquipoId(int id)
        {
            var Equipo = Equipos.FromSqlInterpolated($"exec spGetEquipo {id}").AsEnumerable().FirstOrDefault();
            return Equipo;
        }

        //metodo para insertar datos a la tabla
        public void CrearEquipo(string nombre, string correoE, string lugar, DateTime fechaFundacion, string descripcion, string numIdentificacion, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spInsertarEquipos {0}, {1}, {2}, {3}, {4}, {5}, {6}", nombre,  correoE, lugar, fechaFundacion, descripcion, numIdentificacion, idCampeonato);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarEquipo(int id, string nombre,  string correoE, string lugar, DateTime fechaFundacion, string descripcion, string numIdentificacion, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spActualizarEquipos {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",id, nombre,correoE, lugar, fechaFundacion, descripcion, numIdentificacion, idCampeonato);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarEquipo(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarEquipos {0}", id);
        }

    }
}
