using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextLigas:DbContext
    {
        public DbContextLigas(DbContextOptions<DbContextLigas> options) : base(options)
        {

        }
        //-----------------------------------TIPO SANCIONES----------------------------------------
        //Creando tabla de Tipos de sanciones
        public DbSet<Ligas> Ligas { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Ligas en BD
            builder.Entity<Ligas>().ToTable("Ligas");
            builder.Entity<Ligas>().HasKey(u => u.Id);
            builder.Entity<Ligas>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Ligas>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Ligas>().Property(u => u.Descripcion).HasColumnName("descripcion");
            builder.Entity<Ligas>().Property(u => u.CorreoE).HasColumnName("correoE");
            builder.Entity<Ligas>().Property(u => u.Telefono).HasColumnName("telefono");
            
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<Ligas> ObtenerLigas()
        {
            return Ligas.FromSqlRaw("exec spGetLigas").ToList();

        }

        //metodo para retornar un usuario segun un id
        public Ligas ObtenerLigasId(int id)
        {
            var ligas = Ligas.FromSqlInterpolated($"exec spGetLiga {id}").AsEnumerable().FirstOrDefault();
            return ligas;
        }

        //metodo para insertar datos a la tabla
        public void CrearLiga(string nombre, string descripcion, string correoE, string telefono)
        {
            Database.ExecuteSqlRaw("exec spInsertarLigas {0}, {1}, {2}, {3}", nombre, descripcion, correoE, telefono);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarLiga(int id, string nombre, string descripcion, string correoE, string telefono)
        {
            Database.ExecuteSqlRaw("exec spActualizarLigas {0} ,{1}, {2}, {3}, {4}", id, nombre, descripcion, correoE, telefono);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarLiga(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarLigas {0}", id);
        }

    }

}
