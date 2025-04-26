using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextTipoUsuarios : DbContext
    {
        public DbContextTipoUsuarios(DbContextOptions<DbContextTipoUsuarios> options) : base(options)
        {

        }
        //-----------------------------------Tipo USUARIOS----------------------------------------
        //Creando tabla de Tipo Usuarios
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla Usuarios en BD
            builder.Entity<TipoUsuarios>().ToTable("TipoUsuarios");
            builder.Entity<TipoUsuarios>().HasKey(u => u.Id);
            builder.Entity<TipoUsuarios>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<TipoUsuarios>().Property(u => u.Nombre).HasColumnName("nombre");
            
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<TipoUsuarios> ObtenerTipoUsuarios()
        {
            return TipoUsuarios.FromSqlRaw("exec spGetTipoUsuarios").ToList();

        }

        //metodo para retornar un usuario segun un id
        public TipoUsuarios ObtenerTipoUsuarioId(int id)
        {
            var TipoUsuario = TipoUsuarios.FromSqlInterpolated($"exec spGetTipoUsuario {id}").AsEnumerable().FirstOrDefault();
            return TipoUsuario;
        }

        //metodo para insertar datos a la tabla
        public void CrearTipoUsuario(string nombre )
        {
            Database.ExecuteSqlRaw("exec spInsertarTipoUsuarios {0} ", nombre);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarTipoUsuario(int id, string nombre)
        {
            Database.ExecuteSqlRaw("exec spActualizarTipoUsuarios {0} ,{1}", id, nombre);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarTipoUsuarios(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarTipoUsuarios {0}", id);
        }

    }
    
 }

