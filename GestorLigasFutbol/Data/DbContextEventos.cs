using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextEventos : DbContext
    {
        public DbContextEventos(DbContextOptions<DbContextEventos> options) : base(options)
        {

        }
        //-----------------------------------EVENTOS----------------------------------------
        //Creando tabla de Eventos
        public DbSet<Eventos> Eventos { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Eventos en BD
            builder.Entity<Eventos>().ToTable("Eventos");
            builder.Entity<Eventos>().HasKey(u => u.Id);
            builder.Entity<Eventos>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Eventos>().Property(u => u.Fecha).HasColumnName("fecha");
            builder.Entity<Eventos>().Property(u => u.Hora).HasColumnName("hora");
            builder.Entity<Eventos>().Property(u => u.EquipoVisitante).HasColumnName("equipoVisitante");
            builder.Entity<Eventos>().Property(u => u.EquipoResidente).HasColumnName("equipoResidente");
            builder.Entity<Eventos>().Property(u => u.IdCampeonato).HasColumnName("idCampeonato");
            
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<Eventos> ObtenerEventos()
        {
            return Eventos.FromSqlRaw("exec spGetEventos").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Eventos ObtenerEventoId(int id)
        {
            var eventos = Eventos.FromSqlInterpolated($"exec spGetEvento {id}").AsEnumerable().FirstOrDefault();
            return eventos;
        }

        //metodo para insertar datos a la tabla
        public void CrearEvento(string nombre, DateTime fecha, DateTime hora, int equipoVisitante, int equipoResidente, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spInsertarEventos {0}, {1}, {2}, {3}, {4}, {5}", nombre, fecha, hora, equipoVisitante, equipoResidente, idCampeonato);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarEventos(int id, string nombre, DateTime fecha, DateTime hora, int equipoVisitante, int equipoResidente, int idCampeonato)
        {
            Database.ExecuteSqlRaw("exec spActualizarEventos {0} ,{1}, {2}, {3}, {4}, {5}, {6}", id, nombre, fecha, hora, equipoVisitante, equipoResidente, idCampeonato);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarUsuarios(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarUsuarios {0}", id);
        }

    }
}
