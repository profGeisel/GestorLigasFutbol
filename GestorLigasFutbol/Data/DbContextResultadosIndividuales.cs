using GestorLigasFutbol.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorLigasFutbol.Data
{
    public class DbContextResultadosIndividuales : DbContext
    {
        public DbContextResultadosIndividuales(DbContextOptions<DbContextResultadosIndividuales> options) : base(options)
        {

        }
        //-----------------------------------ResultadosIndividuales----------------------------------------
        //Creando tabla de ResultadosIndividuales
        public DbSet<ResultadosIndividuales> ResultadosIndividuales { get; set; }

        //metodo 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelo y nombre de tabla ResultadosIndividuales en BD
            builder.Entity<ResultadosIndividuales>().ToTable("ResultadosIndividuales");
            builder.Entity<ResultadosIndividuales>().HasKey(u => u.Id);
            builder.Entity<ResultadosIndividuales>().Property(u => u.Id).HasColumnName("id");
            builder.Entity<ResultadosIndividuales>().Property(u => u.IdJugador).HasColumnName("idJugador");
            builder.Entity<ResultadosIndividuales>().Property(u => u.cantidadGoles).HasColumnName("cantidadGoles");
            builder.Entity<ResultadosIndividuales>().Property(u => u.asistencias).HasColumnName("asistencias");
            builder.Entity<ResultadosIndividuales>().Property(u => u.tRojas).HasColumnName("tRojas");
            builder.Entity<ResultadosIndividuales>().Property(u => u.tAmarillas).HasColumnName("tAmarillas");
        }

        //FUNCIONALIDADES PARA HACER USO DE LOS PROCEDIMIENTOS ALMACENADOS ResultadosIndividuales
        //metodo para retornar lista de registros de la tabla
        public List<ResultadosIndividuales> ObtenerUsuarios()
        {
            return ResultadosIndividuales.FromSqlRaw("exec spGetResultadosIndividuales").ToList();

        }

        //metodo para retornar un usuario segun un id
        public ResultadosIndividuales ObtenerResultadoIndividualId(int id)
        {
            var ResultadoIndividual = ResultadosIndividuales.FromSqlInterpolated($"exec spGetResultadoIndividual {id}").AsEnumerable().FirstOrDefault();
            return ResultadoIndividual;
        }

        //metodo para insertar datos a la tabla
        public void CrearResultadoIndividual(int idJugador, int cantidadGoles, int asistencias, int tRojas, int tAmarillas)
        {
            Database.ExecuteSqlRaw("exec spInsertarResultadosIndividuales {0}, {1}, {2}, {3}, {4}", idJugador, cantidadGoles, asistencias, tRojas, tAmarillas);
        }

        //metodo para actualizar datos a la tabla
        public void ActualizarResultadoIndividual(int id, int idJugador, int cantidadGoles, int asistencias, int tRojas, int tAmarillas)
        {
            Database.ExecuteSqlRaw("exec spActualizarResultadosIndividuales {0} ,{1}, {2}, {3}, {4}, {5}",id, idJugador, cantidadGoles, asistencias, tRojas, tAmarillas);
        }


        //metodo para Eliminar datos a la tabla
        public void EliminarResultadoIndividual(int id)
        {
            Database.ExecuteSqlRaw("exec spEliminarUsuarios {0}", id);
        }

    }
}
