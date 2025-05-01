using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextJugadores : DbContext
    {
        public DbContextJugadores(DbContextOptions<DbContextUsuarios> options) : base(options)
        {

        }
        //-----------------------------------JUGADORES----------------------------------------
        //Creando tabla de Jugadores
        public DbSet<Jugadores> Jugadores { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Jugadores en BD
            builder.Entity<Jugadores>().ToTable("Jugadores");
            builder.Entity<Jugadores>().HasKey(u => u.Id);
            builder.Entity<Jugadores>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Jugadores>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Jugadores>().Property(u => u.ApellidoP).HasColumnName("apellidoP");
            builder.Entity<Jugadores>().Property(u => u.ApellidoM).HasColumnName("ApellidoM");
            builder.Entity<Jugadores>().Property(u => u.Foto).HasColumnName("foto");
            builder.Entity<Jugadores>().Property(u => u.NumeroCamisa).HasColumnName("numeroCamissa");
            builder.Entity<Jugadores>().Property(u => u.Fecha_Nacimiento).HasColumnName("fechaNacimiento");
            builder.Entity<Jugadores>().Property(u => u.Edad).HasColumnName("edad");
            builder.Entity<Jugadores>().Property(u => u.Cedula).HasColumnName("cedula");
            builder.Entity<Jugadores>().Property(u => u.IdEquipo).HasColumnName("idEquipo");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<Jugadores> ObtenerJugadores()
        {
            return Jugadores.FromSqlRaw("exec spGetJugadores").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Jugadores ObtenerJugadorId(int id)
        {
            var jugador = Jugadores.FromSqlInterpolated($"exec spGetJugador {id}").AsEnumerable().FirstOrDefault();
            return jugador;
        }

        //metodo para insertar datos a la tabla
        public void CrearJugador(string nombre, string apellidoP, string apellidoM, byte foto, int numeroCamisa, DateOnly fechaNacimiento, int edad, string cedula, int idEquipo)
        {
            Database.ExecuteSqlRaw("exec spInsertarJugadores {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", nombre, apellidoP, apellidoM, foto, numeroCamisa, fechaNacimiento, edad, cedula, idEquipo);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarJugador(int id, string nombre, string apellidoP, string apellidoM, byte foto, int numeroCamisa, DateOnly fechaNacimiento, int edad, string cedula, int idEquipo)
        {
            Database.ExecuteSqlRaw("exec spActualizarJugadores {0} ,{1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", id, nombre, apellidoP, apellidoM, foto, numeroCamisa, fechaNacimiento, edad, cedula, idEquipo);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarJugador(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarJugadores {0}", id);
        }

    }
}
