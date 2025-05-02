using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextEquipos : DbContext
    {
        public DbContextEquipos(DbContextOptions<DbContextEquipos> options) : base(options)
        {

        }
        //-----------------------------------USUARIOS----------------------------------------
        //Creando tabla de Usuarios
        public DbSet<Equipos> Equipos { get; set; }

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

        //metodo para retornar un usuario segun un id
        public Equipos ObtenerEquipoId(int id)
        {
            var Equipo = Equipos.FromSqlInterpolated($"exec spGetEquipos {id}").AsEnumerable().FirstOrDefault();
            return Equipo;
        }

        //metodo para insertar datos a la tabla
        public void CrearEquipo(string nombre, string correoE, string lugar, string capitan, DateOnly fechaFundacion, string descripcion, int numIdentificacion, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spInsertarEquipos {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", nombre, correoE, lugar, capitan, fechaFundacion, descripcion, numIdentificacion, idCampeonato);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarEquipo(int id, string nombre, string correoE, string lugar, string capitan, DateOnly fechaFundacion, string descripcion, int numIdentificacion, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spActualizarEquipos {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",id, nombre, correoE, lugar, capitan, fechaFundacion, descripcion, numIdentificacion, idCampeonato);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarEquipo(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarEquipos {0}", id);
        }

    }
}
