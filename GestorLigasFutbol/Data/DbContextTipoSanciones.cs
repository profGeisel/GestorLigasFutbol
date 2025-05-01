using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextTipoSanciones:DbContext
    {
        public DbContextTipoSanciones(DbContextOptions<DbContextTipoSanciones> options) : base(options)
        {

        }
        //-----------------------------------TIPO SANCIONES----------------------------------------
        //Creando tabla de Tipos de sanciones
        public DbSet<TipoSanciones> TipoSanciones { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla TipoSanciones en BD
            builder.Entity<TipoSanciones>().ToTable("TipoSanciones");
            builder.Entity<TipoSanciones>().HasKey(u => u.Id);
            builder.Entity<TipoSanciones>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<TipoSanciones>().Property(u => u.Nombre).HasColumnName("nombre");
            builder.Entity<TipoSanciones>().Property(u => u.Descripcion).HasColumnName("descripcion");
            builder.Entity<TipoSanciones>().Property(u => u.Tiempo).HasColumnName("tiempo");
            builder.Entity<TipoSanciones>().Property(u => u.Valor).HasColumnName("valor");
            builder.Entity<TipoSanciones>().Property(u => u.Estado).HasColumnName("estado");
            builder.Entity<TipoSanciones>().Property(u => u.IdLiga).HasColumnName("idLiga");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS Usuarios
        //metodo para retornar lista de registros de la tabla
        public List<TipoSanciones> ObtenerTipoSanciones()
        {
            return TipoSanciones.FromSqlRaw("exec spGetTipoSanciones").ToList();

        }

        //metodo para retornar un usuario segun un id
        public TipoSanciones ObtenerTipoSancionId(int id)
        {
            var tSanciones = TipoSanciones.FromSqlInterpolated($"exec spGetTipoSancion {id}").AsEnumerable().FirstOrDefault();
            return tSanciones;
        }

        //metodo para insertar datos a la tabla
        public void CrearTipoSancion(string nombre, string descripcion, int tiempo, int valor, string estado, int idLiga)
        {
            Database.ExecuteSqlRaw("exec spInsertarTipoSanciones {0}, {1}, {2}, {3}, {4}, {5}", nombre, descripcion, tiempo, valor, estado, idLiga);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarTipoSancion(int id, string nombre, string descripcion, int tiempo, int valor, string estado, int idLiga)
        {
            Database.ExecuteSqlRaw("exec spActualizarTipoSanciones {0} ,{1}, {2}, {3}, {4}, {5}, {6}", id, nombre, descripcion, tiempo, valor, estado, idLiga);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarTipoSancion(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarTipoSanciones {0}", id);
        }

    }

}
