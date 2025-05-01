using System.Data;
using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextEntrenadores : DbContext
    {
        public DbContextEntrenadores(DbContextOptions<DbContextEntrenadores> options) : base(options)
        {

        }
        //-----------------------------------Entrenadores----------------------------------------
        //Creando tabla de Entrenadores
        public DbSet<Entrenadores> Entrenadores { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Entrenadores en BD
            builder.Entity<Entrenadores>().ToTable("Entrenadores");
            builder.Entity<Entrenadores>().HasKey(u => u.Id);
            builder.Entity<Entrenadores>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Entrenadores>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Entrenadores>().Property(u => u.ApellidoP).HasColumnName("apellidoP");
            builder.Entity<Entrenadores>().Property(u => u.ApellidoM).HasColumnName("ApellidoM");
            builder.Entity<Entrenadores>().Property(u => u.Foto).HasColumnName("foto");
            builder.Entity<Entrenadores>().Property(u => u.FechaNacimiento).HasColumnName("fechaNacimiento");
            builder.Entity<Entrenadores>().Property(u => u.CorreoE).HasColumnName("correoE");
            builder.Entity<Entrenadores>().Property(u => u.Cedula).HasColumnName("cedula");
            builder.Entity<Entrenadores>().Property(u => u.IdEquipo).HasColumnName("idEquipo");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Entrenadores
        //metodo para retornar lista de registros de la tabla
        public List<Entrenadores> ObtenerUsuarios()
        {
            return Entrenadores.FromSqlRaw("exec spGetEntrenadores").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Entrenadores ObtenerEntrenadorId(int id)
        {
            var entrenador = Entrenadores.FromSqlInterpolated($"exec spGetEntrenadores {id}").AsEnumerable().FirstOrDefault();
            return entrenador;
        }

        //metodo para insertar datos a la tabla
        public void CrearEntrenador(string nombre, string apellidoP, string apellidoM,byte foto, DateOnly fechaNacimiento, string correoE, string cedula, int idEquipo)
        {
            Database.ExecuteSqlRaw("exec spInsertarEntrenadores {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", nombre, apellidoP, apellidoM, foto, fechaNacimiento, correoE, cedula, idEquipo);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarEntrenador(int id, string nombre, string apellidoP, string apellidoM, byte foto, DateOnly fechaNacimiento, string correoE, string cedula, int idEquipo)
        {
            Database.ExecuteSqlRaw("exec spActualizarEntrenadores {0} ,{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", id, nombre, apellidoP, apellidoM, foto, fechaNacimiento, correoE, cedula, idEquipo);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarEntrenador(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarEntrenadores {0}", id);
        }

    }
}
