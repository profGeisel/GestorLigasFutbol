using GestorLigasFutbol.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextUsuarios : DbContext
    {
        public DbContextUsuarios(DbContextOptions<DbContextUsuarios> options) : base(options)
        {

        }
        //-----------------------------------USUARIOS----------------------------------------
        //Creando tabla de Usuarios
        public DbSet<Usuarios> Usuarios { get; set; }

        //DbSet para el llenado de combo
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Usuarios en BD
            builder.Entity<Usuarios>().ToTable("Usuarios");
            builder.Entity<Usuarios>().HasKey(u => u.Id);
            builder.Entity<Usuarios>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<Usuarios>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<Usuarios>().Property(u => u.ApellidoP).HasColumnName("apellidoP");
            builder.Entity<Usuarios>().Property(u => u.ApellidoM).HasColumnName("ApellidoM");
            builder.Entity<Usuarios>().Property(u => u.CorreoE).HasColumnName("correoE");
            builder.Entity<Usuarios>().Property(u => u.Contrasena).HasColumnName("contrasena");
            builder.Entity<Usuarios>().Property(u => u.IdTipoUsuarios).HasColumnName("idTipoUsuario");

        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<Usuarios> ObtenerUsuarios()
        {
            return Usuarios.FromSqlRaw("exec spGetUsuarios").ToList();

        }



        //metodo para retornar un usuario segun un id
        public Usuarios ObtenerUsuarioId(int id)
        {
            var Usuario = Usuarios.FromSqlInterpolated($"exec spGetUsuario {id}").AsEnumerable().FirstOrDefault();
            return Usuario;
        }

        //metodo para insertar datos a la tabla
        public void CrearUsuario(string nombre, string apellidoP, string apellidoM, string correoE, string contrasena, int idTipoUsuario)
        {
            Database.ExecuteSqlRaw("exec spInsertarUsuarios {0}, {1}, {2}, {3}, {4}, {5}", nombre, apellidoP, apellidoM, correoE, contrasena, idTipoUsuario);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarUsuario(int id, string nombre, string apellidoP, string apellidoM, string correoE, string contrasena, int idTipoUsuario)
        {
            Database.ExecuteSqlRaw("exec spActualizarUsuario {0} ,{1}, {2}, {3}, {4}, {5}, {6}", id, nombre, apellidoP, apellidoM, correoE, contrasena, idTipoUsuario);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarUsuarios(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarUsuarios {0}", id);
        }

    }
}
